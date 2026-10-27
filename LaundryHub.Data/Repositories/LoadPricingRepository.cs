using Dapper;
using LaundryHub.Core.Models;

namespace LaundryHub.Data.Repositories;

public sealed class LoadPricingRepository
{
    private readonly DbContext _db;

    public LoadPricingRepository(DbContext db) => _db = db;

    public IEnumerable<LoadPrice> GetAll()
    {
        using var conn = _db.CreateConnection();
        return conn.Query<LoadPrice>(
            "SELECT category, load_size, max_weight_kg, price FROM load_prices ORDER BY category, max_weight_kg");
    }

    public void UpdatePrices(IEnumerable<LoadPrice> prices)
    {
        var priceList = prices.ToList();
        if (priceList.Any(price => price.Price <= 0))
            throw new ArgumentOutOfRangeException(nameof(prices), "Prices must be greater than zero.");

        using var conn = _db.CreateConnection();
        using var transaction = conn.BeginTransaction();
        foreach (var price in priceList)
        {
            var updated = conn.Execute(
                "UPDATE load_prices SET price = @Price WHERE category = @Category AND load_size = @LoadSize",
                price, transaction);
            if (updated != 1)
                throw new InvalidOperationException($"Pricing row '{price.Category} / {price.LoadSize}' was not found.");
        }

        transaction.Commit();
    }
}
