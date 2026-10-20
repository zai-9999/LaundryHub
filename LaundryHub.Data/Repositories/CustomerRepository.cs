using Dapper;
using LaundryHub.Core.Interfaces;
using LaundryHub.Core.Models;

namespace LaundryHub.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbContext _db;

    public CustomerRepository(DbContext db) => _db = db;

    public Customer? GetById(int customerId)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<Customer>(
            "SELECT * FROM customers WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });
    }

    public Customer? GetByUserId(int userId)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<Customer>(
            "SELECT * FROM customers WHERE user_id = @UserId AND is_archived = FALSE",
            new { UserId = userId });
    }

    public IEnumerable<Customer> Search(string term)
    {
        using var conn = _db.CreateConnection();
        return conn.Query<Customer>(@"
            SELECT * FROM customers
            WHERE is_archived = FALSE
              AND (full_name ILIKE @Term OR phone ILIKE @Term)
            ORDER BY full_name
            LIMIT 50",
            new { Term = $"%{term}%" });
    }

    public IEnumerable<Customer> GetAll(bool includeArchived = false)
    {
        using var conn = _db.CreateConnection();
        var sql = includeArchived
            ? "SELECT * FROM customers ORDER BY full_name"
            : "SELECT * FROM customers WHERE is_archived = FALSE ORDER BY full_name";
        return conn.Query<Customer>(sql);
    }

    public int Add(Customer customer)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(@"
            INSERT INTO customers (user_id, full_name, phone, email, address)
            VALUES (@UserId, @FullName, @Phone, @Email, @Address)
            RETURNING customer_id",
            customer);
    }

    public void Update(Customer customer)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE customers
            SET full_name = @FullName, phone = @Phone, email = @Email, address = @Address
            WHERE customer_id = @CustomerId",
            customer);
    }

    public void Archive(int customerId)
    {
        if (HasActiveOrders(customerId))
        {
            throw new InvalidOperationException("Cannot archive customer with active orders. Please complete or cancel all orders first.");
        }

        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE customers SET is_archived = TRUE WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });

    }

    public void Restore(int customerId)
    {
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE customers SET is_archived = FALSE WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });

        // Restore all orders for this customer
        conn.Execute("UPDATE orders SET is_archived = FALSE WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });
    }

    /// <summary>
    /// Archives all orders for customers that are already archived but have active orders.
    /// Use this to clean up data after changing the archive behavior.
    /// </summary>
    public void CleanupArchivedCustomerOrders()
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE orders
            SET is_archived = TRUE
            WHERE customer_id IN (SELECT customer_id FROM customers WHERE is_archived = TRUE)
              AND is_archived = FALSE");
    }

    public bool PhoneExists(string phone, int excludeCustomerId = 0)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(@"
            SELECT COUNT(1) FROM customers
            WHERE phone = @Phone AND customer_id != @ExcludeId",
            new { Phone = phone, ExcludeId = excludeCustomerId }) > 0;
    }

    public bool HasActiveOrders(int customerId)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(@"
            SELECT COUNT(1) FROM orders
            WHERE customer_id = @CustomerId AND is_archived = FALSE
              AND status NOT IN ('Claimed', 'Cancelled')",
            new { CustomerId = customerId }) > 0;
    }

    public Customer? GetByPhone(string phone)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<Customer>(
            "SELECT * FROM customers WHERE phone = @Phone AND is_archived = FALSE",
            new { Phone = phone });
    }

    public int RegisterCustomerWithUser(User user, Customer customer)
    {
        using var conn = _db.CreateConnection();
        if (conn.State != System.Data.ConnectionState.Open) conn.Open();
        using var tran = conn.BeginTransaction();
        try
        {
            int userId = conn.ExecuteScalar<int>(@"
                INSERT INTO users (username, password_hash, full_name, email, role, is_active)
                VALUES (@Username, @PasswordHash, @FullName, @Email, @Role, @IsActive)
                RETURNING user_id",
                user, transaction: tran);

            customer.UserId = userId;

            // Check if walk-in customer already exists with this phone without a linked user account
            var existing = conn.QueryFirstOrDefault<Customer>(@"
                SELECT * FROM customers
                WHERE phone = @Phone AND is_archived = FALSE
                FOR UPDATE",
                new { Phone = customer.Phone }, transaction: tran);

            int customerId;
            if (existing != null)
            {
                if (existing.UserId != null)
                {
                    throw new InvalidOperationException("This phone number is already registered to another account.");
                }

                // Link existing customer profile
                conn.Execute(@"
                    UPDATE customers
                    SET user_id = @UserId,
                        full_name = @FullName,
                        email = COALESCE(@Email, email),
                        address = COALESCE(@Address, address)
                    WHERE customer_id = @CustomerId",
                    new
                    {
                        UserId = userId,
                        FullName = customer.FullName,
                        Email = customer.Email,
                        Address = customer.Address,
                        CustomerId = existing.CustomerId
                    }, transaction: tran);

                customerId = existing.CustomerId;
            }
            else
            {
                customerId = conn.ExecuteScalar<int>(@"
                    INSERT INTO customers (user_id, full_name, phone, email, address)
                    VALUES (@UserId, @FullName, @Phone, @Email, @Address)
                    RETURNING customer_id",
                    customer, transaction: tran);
            }

            customer.CustomerId = customerId;
            tran.Commit();
            return customerId;
        }
        catch
        {
            tran.Rollback();
            throw;
        }
    }
}
