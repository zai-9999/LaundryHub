using Dapper;
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
    public static LoadPricingRepository  LoadPricing   { get; private set; } = null!;

    public static string ShopName => Configuration["App:ShopName"] ?? "LaundryHub";

    public static void Initialize()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        DbContext    = new DbContext(Configuration);
        Users        = new UserRepository(DbContext);
        Customers    = new CustomerRepository(DbContext);
        Orders       = new OrderRepository(DbContext);
        ServiceTypes = new ServiceTypeRepository(DbContext);
        LoadPricing  = new LoadPricingRepository(DbContext);
    }

    /// <summary>Tests the DB connection and applies pending schema migrations.</summary>
    public static void TestConnection()
    {
        using var conn = DbContext.CreateConnection();
        conn.Execute(@"
            ALTER TABLE orders ADD COLUMN IF NOT EXISTS laundry_category VARCHAR(40) NOT NULL DEFAULT 'Clothes';
            ALTER TABLE orders DROP CONSTRAINT IF EXISTS orders_laundry_category_check;
            ALTER TABLE orders ADD CONSTRAINT orders_laundry_category_check
                CHECK (laundry_category IN ('Clothes','Bedsheets/Towels/Blankets'));

            CREATE TABLE IF NOT EXISTS load_prices (
                category      VARCHAR(40)  NOT NULL
                              CHECK (category IN ('Clothes','Bedsheets/Towels/Blankets')),
                load_size     VARCHAR(10)  NOT NULL
                              CHECK (load_size IN ('SMALL','MEDIUM','LARGE')),
                max_weight_kg NUMERIC(5,2) NOT NULL CHECK (max_weight_kg > 0),
                price         NUMERIC(10,2) NOT NULL CHECK (price > 0),
                PRIMARY KEY (category, load_size)
            );

            INSERT INTO load_prices (category, load_size, max_weight_kg, price) VALUES
                ('Clothes', 'SMALL', 5.00, 330.00),
                ('Clothes', 'MEDIUM', 8.00, 440.00),
                ('Clothes', 'LARGE', 15.00, 550.00),
                ('Bedsheets/Towels/Blankets', 'SMALL', 3.00, 440.00),
                ('Bedsheets/Towels/Blankets', 'MEDIUM', 5.00, 650.00),
                ('Bedsheets/Towels/Blankets', 'LARGE', 9.00, 1120.00)
            ON CONFLICT (category, load_size) DO NOTHING;
        ");
    }
}
