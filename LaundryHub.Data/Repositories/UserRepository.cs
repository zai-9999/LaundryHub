using Dapper;
using LaundryHub.Core.Interfaces;
using LaundryHub.Core.Models;

namespace LaundryHub.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _db;

    public UserRepository(DbContext db) => _db = db;

    public User? GetByUsername(string username)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<User>(
            "SELECT * FROM users WHERE (LOWER(username) = LOWER(@Username) OR LOWER(email) = LOWER(@Username))",
            new { Username = username });
    }

    public User? GetById(int userId)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<User>(
            "SELECT * FROM users WHERE user_id = @UserId",
            new { UserId = userId });
    }

    public IEnumerable<User> GetAllStaff()
    {
        using var conn = _db.CreateConnection();
        return conn.Query<User>(
            "SELECT * FROM users WHERE role IN ('Staff','Admin') ORDER BY full_name");
    }

    public void Add(User user)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            INSERT INTO users (username, password_hash, full_name, email, role, is_active)
            VALUES (@Username, @PasswordHash, @FullName, @Email, @Role, @IsActive)",
            user);
    }

    public void Update(User user)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE users
            SET full_name = @FullName,
                email = @Email,
                role = @Role,
                is_active = @IsActive,
                password_hash = CASE WHEN @PasswordHash IS NOT NULL AND @PasswordHash != '' THEN @PasswordHash ELSE password_hash END
            WHERE user_id = @UserId",
            user);
    }

    public void SetActive(int userId, bool isActive)
    {
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE users SET is_active = @IsActive WHERE user_id = @UserId",
            new { IsActive = isActive, UserId = userId });
    }

    public bool UsernameExists(string username, int excludeUserId = 0)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM users WHERE LOWER(username) = LOWER(@Username) AND user_id != @ExcludeId",
            new { Username = username, ExcludeId = excludeUserId }) > 0;
    }

    public bool EmailExists(string email, int excludeUserId = 0)
    {
        using var conn = _db.CreateConnection();
        return conn.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM users WHERE LOWER(email) = LOWER(@Email) AND user_id != @ExcludeId",
            new { Email = email, ExcludeId = excludeUserId }) > 0;
    }
}
