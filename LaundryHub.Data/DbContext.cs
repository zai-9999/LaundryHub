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
    static DbContext()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    private readonly string _connectionString;

    public DbContext(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found in appsettings.json.");

        if (_connectionString.Contains("Password=SET_IN_ENV", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Database connection password is still 'SET_IN_ENV'.\n" +
                "Please configure the 'ConnectionStrings__Default' environment variable (e.g. via setx) " +
                "and restart your application / IDE so the updated environment takes effect.");
        }
    }

    /// <summary>Opens and returns a new database connection.</summary>
    public IDbConnection CreateConnection()
    {
        var conn = new NpgsqlConnection(_connectionString);
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
        return conn;
    }
}
