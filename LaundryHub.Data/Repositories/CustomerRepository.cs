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
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE customers SET is_archived = TRUE WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });
    }

    public void Restore(int customerId)
    {
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE customers SET is_archived = FALSE WHERE customer_id = @CustomerId",
            new { CustomerId = customerId });
    }

    public bool PhoneExists(string phone, int excludeCustomerId = 0)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(@"
            SELECT COUNT(1) FROM customers
            WHERE phone = @Phone AND customer_id != @ExcludeId",
            new { Phone = phone, ExcludeId = excludeCustomerId }) > 0;
    }
}
