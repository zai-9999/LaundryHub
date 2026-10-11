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
        return conn.ExecuteScalar<int>(@"
            INSERT INTO orders
              (order_number, customer_id, service_id, weight_kg, total_amount,
               status, created_by, pickup_date)
            VALUES
              (@OrderNumber, @CustomerId, @ServiceId, @WeightKg, @TotalAmount,
               @Status, @CreatedBy, @PickupDate)
            RETURNING order_id",
            order);
    }

    public void UpdateStatus(int orderId, string newStatus, string? cancelReason = null)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE orders
            SET status = @Status,
                cancel_reason = @CancelReason,
                claimed_at = CASE WHEN @Status = 'Claimed' THEN NOW() ELSE claimed_at END,
                updated_at = NOW()
            WHERE order_id = @OrderId",
            new { Status = newStatus, CancelReason = cancelReason, OrderId = orderId });
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
        var count = conn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM orders WHERE order_number LIKE @Prefix",
            new { Prefix = $"{prefix}%" });
        return $"{prefix}{(count + 1):D3}";
    }

    public DailyReport GetDailyReport(DateTime date)
    {
        using var conn = _db.CreateConnection();
        var orders = conn.Query<Order>($@"
            {SelectJoined}
            WHERE DATE(o.created_at) = @Date AND o.is_archived = FALSE
            ORDER BY o.created_at DESC",
            new { Date = date.Date }).ToList();

        return new DailyReport
        {
            ReportDate = date.Date,
            TotalOrders = orders.Count,
            PendingOrders = orders.Count(o => o.Status is "Washing" or "Drying" or "Ready for Pickup"),
            ClaimedOrders = orders.Count(o => o.Status == "Claimed"),
            CancelledOrders = orders.Count(o => o.Status == "Cancelled"),
            TotalSales = orders.Where(o => o.Status == "Claimed").Sum(o => o.TotalAmount),
            Orders = orders
        };
    }
}
