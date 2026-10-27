using Dapper;
using LaundryHub.Core.Interfaces;
using LaundryHub.Core.Models;

namespace LaundryHub.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DbContext _db;

    public OrderRepository(DbContext db) => _db = db;

    private const string SelectJoined = @"
        SELECT o.*, c.full_name AS customer_name, c.phone AS customer_phone,
               s.service_name, u.full_name AS created_by_name
        FROM orders o
        JOIN customers c ON c.customer_id = o.customer_id
        JOIN service_types s ON s.service_id = o.service_id
        LEFT JOIN users u ON u.user_id = o.created_by";

    public Order? GetById(int orderId)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<Order>(
            $"{SelectJoined} WHERE o.order_id = @OrderId",
            new { OrderId = orderId });
    }

    public Order? GetByOrderNumber(string orderNumber)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<Order>(
            $"{SelectJoined} WHERE o.order_number = @OrderNumber",
            new { OrderNumber = orderNumber });
    }

    public IEnumerable<Order> GetAll(bool includeArchived = false)
    {
        using var conn = _db.CreateConnection();
        var where = includeArchived ? "" : "WHERE o.is_archived = FALSE";
        return conn.Query<Order>($"{SelectJoined} {where} ORDER BY o.created_at DESC");
    }

    public IEnumerable<Order> GetByCustomer(int customerId)
    {
        using var conn = _db.CreateConnection();
        return conn.Query<Order>(
            $"{SelectJoined} WHERE o.customer_id = @CustomerId AND o.is_archived = FALSE ORDER BY o.created_at DESC",
            new { CustomerId = customerId });
    }

    public IEnumerable<Order> GetByDate(DateTime date)
    {
        using var conn = _db.CreateConnection();
        return conn.Query<Order>(
            $"{SelectJoined} WHERE DATE(o.created_at) = @Date AND o.is_archived = FALSE ORDER BY o.created_at DESC",
            new { Date = date.Date });
    }

    public IEnumerable<Order> Search(string term)
    {
        using var conn = _db.CreateConnection();
        return conn.Query<Order>($@"
            {SelectJoined}
            WHERE o.is_archived = FALSE
              AND (o.order_number ILIKE @Term OR c.full_name ILIKE @Term)
            ORDER BY o.created_at DESC
            LIMIT 100",
            new { Term = $"%{term}%" });
    }

    public int Add(Order order)
    {
        using var conn = _db.CreateConnection();
        if (conn.State != System.Data.ConnectionState.Open) conn.Open();
        using var tran = conn.BeginTransaction();
        try
        {
            // Acquire PostgreSQL advisory transaction lock to serialize order number generation between concurrent terminals
            conn.Execute("SELECT pg_advisory_xact_lock(742189);", transaction: tran);

            var today = DateTime.Today;
            var prefix = $"LH-{today:yyyyMMdd}-";

            var maxSeq = conn.ExecuteScalar<int?>(@"
                SELECT MAX(CAST(SUBSTRING(order_number FROM '\d+$') AS INTEGER))
                FROM orders
                WHERE order_number LIKE @Prefix",
                new { Prefix = $"{prefix}%" }, transaction: tran) ?? 0;

            bool exists = false;
            if (!string.IsNullOrWhiteSpace(order.OrderNumber))
            {
                exists = conn.ExecuteScalar<int>(@"
                    SELECT COUNT(1) FROM orders WHERE order_number = @OrderNumber",
                    new { order.OrderNumber }, transaction: tran) > 0;
            }

            if (string.IsNullOrWhiteSpace(order.OrderNumber) || exists)
            {
                order.OrderNumber = $"{prefix}{(maxSeq + 1):D3}";
            }

            int orderId = conn.ExecuteScalar<int>(@"
                INSERT INTO orders
                  (order_number, customer_id, service_id, laundry_category, weight_kg, total_amount,
                   status, created_by, pickup_date)
                VALUES
                  (@OrderNumber, @CustomerId, @ServiceId, @LaundryCategory, @WeightKg, @TotalAmount,
                   @Status, @CreatedBy, @PickupDate)
                RETURNING order_id",
                order, transaction: tran);

            // Record initial status in order_status_log
            conn.Execute(@"
                INSERT INTO order_status_log (order_id, old_status, new_status, changed_by, notes)
                VALUES (@OrderId, NULL, @NewStatus, @ChangedBy, 'Order created')",
                new { OrderId = orderId, NewStatus = order.Status ?? "Booked", ChangedBy = order.CreatedBy },
                transaction: tran);

            tran.Commit();
            return orderId;
        }
        catch
        {
            tran.Rollback();
            throw;
        }
    }

    private static bool IsValidTransition(string? from, string to) => (from, to) switch
    {
        ("Washing", "Drying") => true,
        ("Drying", "Ready for Pickup") => true,
        ("Ready for Pickup", "Claimed") => true,
        ("Washing" or "Drying" or "Ready for Pickup", "Cancelled") => true,
        _ => false
    };

    public bool ConfirmDropOff(int orderId)
    {
        using var conn = _db.CreateConnection();
        return conn.Execute(@"
            UPDATE orders
            SET status = 'Washing', updated_at = NOW()
            WHERE order_id = @OrderId AND status = 'Booked'",
            new { OrderId = orderId }) > 0;
    }

    public bool UpdateConfirmedWeight(int orderId, decimal weightKg, decimal totalAmount)
    {
        using var conn = _db.CreateConnection();
        return conn.Execute(@"
            UPDATE orders
            SET weight_kg = @WeightKg,
                total_amount = @TotalAmount,
                updated_at = NOW()
            WHERE order_id = @OrderId
              AND status IN ('Washing', 'Drying', 'Ready for Pickup')
              AND payment_recorded = FALSE",
            new { OrderId = orderId, WeightKg = weightKg, TotalAmount = totalAmount }) > 0;
    }

    public void UpdateStatus(int orderId, string newStatus, string? cancelReason = null, int? changedBy = null, string? notes = null)
    {
        using var conn = _db.CreateConnection();
        if (conn.State != System.Data.ConnectionState.Open) conn.Open();
        using var tran = conn.BeginTransaction();
        try
        {
            var oldStatus = conn.ExecuteScalar<string?>("SELECT status FROM orders WHERE order_id = @OrderId FOR UPDATE", new { OrderId = orderId }, transaction: tran);

            if (!IsValidTransition(oldStatus, newStatus))
                throw new InvalidOperationException($"An order cannot move from '{oldStatus}' to '{newStatus}'.");

            conn.Execute(@"
                UPDATE orders
                SET status = @Status,
                    cancel_reason = @CancelReason,
                    claimed_at = CASE WHEN @Status = 'Claimed' THEN NOW() ELSE claimed_at END,
                    updated_at = NOW()
                WHERE order_id = @OrderId",
                new { Status = newStatus, CancelReason = cancelReason, OrderId = orderId }, transaction: tran);

            // Record status transition in order_status_log
            conn.Execute(@"
                INSERT INTO order_status_log (order_id, old_status, new_status, changed_by, notes)
                VALUES (@OrderId, @OldStatus, @NewStatus, @ChangedBy, @Notes)",
                new
                {
                    OrderId = orderId,
                    OldStatus = oldStatus,
                    NewStatus = newStatus,
                    ChangedBy = changedBy,
                    Notes = notes ?? cancelReason
                }, transaction: tran);

            tran.Commit();
        }
        catch
        {
            tran.Rollback();
            throw;
        }
    }

    public void RecordPayment(int orderId, decimal amountPaid)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE orders
            SET payment_recorded = TRUE, amount_paid = @AmountPaid, updated_at = NOW()
            WHERE order_id = @OrderId",
            new { AmountPaid = amountPaid, OrderId = orderId });
    }

    public void ClaimOrderWithPayment(int orderId, decimal amountPaid, int? changedBy = null, string? notes = null)
    {
        using var conn = _db.CreateConnection();
        if (conn.State != System.Data.ConnectionState.Open) conn.Open();
        using var tran = conn.BeginTransaction();
        try
        {
            var oldStatus = conn.ExecuteScalar<string?>(
                "SELECT status FROM orders WHERE order_id = @OrderId FOR UPDATE",
                new { OrderId = orderId }, transaction: tran);

            if (oldStatus != "Ready for Pickup")
                throw new InvalidOperationException($"Only orders that are Ready for Pickup can be claimed (this one is '{oldStatus}').");

            var total = conn.ExecuteScalar<decimal>(
                "SELECT total_amount FROM orders WHERE order_id = @OrderId",
                new { OrderId = orderId }, transaction: tran);
            if (amountPaid < total)
                throw new InvalidOperationException("Payment is less than the total due.");

            conn.Execute(@"
                UPDATE orders
                SET status = 'Claimed',
                    payment_recorded = TRUE,
                    amount_paid = @AmountPaid,
                    claimed_at = NOW(),
                    updated_at = NOW()
                WHERE order_id = @OrderId",
                new { OrderId = orderId, AmountPaid = amountPaid }, transaction: tran);

            conn.Execute(@"
                INSERT INTO order_status_log (order_id, old_status, new_status, changed_by, notes)
                VALUES (@OrderId, @OldStatus, 'Claimed', @ChangedBy, @Notes)",
                new
                {
                    OrderId = orderId,
                    OldStatus = oldStatus,
                    ChangedBy = changedBy,
                    Notes = notes
                }, transaction: tran);

            tran.Commit();
        }
        catch
        {
            tran.Rollback();
            throw;
        }
    }

    public void Archive(int orderId)
    {
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE orders SET is_archived = TRUE WHERE order_id = @OrderId",
            new { OrderId = orderId });
    }

    public string GenerateOrderNumber()
    {
        using var conn = _db.CreateConnection();
        var today = DateTime.Today;
        var prefix = $"LH-{today:yyyyMMdd}-";
        var maxSeq = conn.ExecuteScalar<int?>(@"
            SELECT MAX(CAST(SUBSTRING(order_number FROM '\d+$') AS INTEGER))
            FROM orders
            WHERE order_number LIKE @Prefix",
            new { Prefix = $"{prefix}%" }) ?? 0;
        return $"{prefix}{(maxSeq + 1):D3}";
    }

    public DailyReport GetDailyReport(DateTime date)
    {
        using var conn = _db.CreateConnection();

        // Orders created on this date (this is the list shown in the grid)
        var orders = conn.Query<Order>($@"
        {SelectJoined}
        WHERE DATE(o.created_at) = @Date AND o.is_archived = FALSE
        ORDER BY o.created_at DESC",
            new { Date = date.Date }).ToList();

        // Pending = every unfinished order, whatever day it was created
        var pending = conn.ExecuteScalar<int>(@"
        SELECT COUNT(1) FROM orders
        WHERE is_archived = FALSE
          AND status IN ('Washing', 'Drying', 'Ready for Pickup')");

        // Sales = money collected on this date (claimed and paid that day),
        // using the order total, not the cash handed over
        var sales = conn.ExecuteScalar<decimal>(@"
        SELECT COALESCE(SUM(total_amount), 0) FROM orders
        WHERE is_archived = FALSE
          AND status = 'Claimed'
          AND payment_recorded = TRUE
          AND DATE(claimed_at) = @Date",
            new { Date = date.Date });

        return new DailyReport
        {
            ReportDate = date.Date,
            TotalOrders = orders.Count,
            PendingOrders = pending,
            ClaimedOrders = orders.Count(o => o.Status == "Claimed"),
            CancelledOrders = orders.Count(o => o.Status == "Cancelled"),
            TotalSales = sales,
            Orders = orders
        };
    }
}
