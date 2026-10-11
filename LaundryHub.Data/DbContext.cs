using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace LaundryHub.Data;

/// <summary>
/// Factory for creating Npgsql database connections.
/// Reads the connection string from appsettings.json.
/// </summary>
public class DbContext
{
    private readonly string _connectionString;

    public DbContext(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found in appsettings.json.");
    }

    /// <summary>Opens and returns a new database connection.</summary>
    public IDbConnection CreateConnection()
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        return conn;
    }
}
