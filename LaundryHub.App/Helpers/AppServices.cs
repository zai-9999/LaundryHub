using Microsoft.Extensions.Configuration;
using LaundryHub.Data;
using LaundryHub.Data.Repositories;

namespace LaundryHub.App.Helpers;

/// <summary>
/// Central service locator that wires up configuration and repositories.
/// Call AppServices.Initialize() once at startup (Program.cs).
/// </summary>
public static class AppServices
{
    public static IConfiguration Configuration { get; private set; } = null!;
    public static DbContext DbContext { get; private set; } = null!;

    public static UserRepository         Users         { get; private set; } = null!;
    public static CustomerRepository     Customers     { get; private set; } = null!;
    public static OrderRepository        Orders        { get; private set; } = null!;
    public static ServiceTypeRepository  ServiceTypes  { get; private set; } = null!;

    public static string ShopName => Configuration["App:ShopName"] ?? "LaundryHub";

    public static void Initialize()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        DbContext    = new DbContext(Configuration);
        Users        = new UserRepository(DbContext);
        Customers    = new CustomerRepository(DbContext);
        Orders       = new OrderRepository(DbContext);
        ServiceTypes = new ServiceTypeRepository(DbContext);
    }

    /// <summary>Tests the DB connection and throws if it fails.</summary>
    public static void TestConnection()
    {
        using var conn = DbContext.CreateConnection();
        // If no exception, connection is good
    }
}
