namespace LaundryHub.Core.Models;

public sealed class LoadPrice
{
    public string Category { get; set; } = string.Empty;
    public string LoadSize { get; set; } = string.Empty;
    public decimal MaxWeightKg { get; set; }
    public decimal Price { get; set; }
}

public sealed class LoadPriceQuote
{
    public decimal Total { get; init; }
    public decimal WeightKg { get; init; }
    public IReadOnlyList<(string LoadSize, decimal MaxWeightKg, int Count)> Loads { get; init; }
        = Array.Empty<(string, decimal, int)>();

    public string GetBreakdown()
    {
        var remainingWeight = WeightKg;
        var allocation = new List<string>();
        foreach (var load in Loads.OrderByDescending(load => load.MaxWeightKg))
        {
            for (var index = 0; index < load.Count; index++)
            {
                var weight = Math.Min(remainingWeight, load.MaxWeightKg);
                allocation.Add($"{load.LoadSize} {weight:0.##} kg");
                remainingWeight -= weight;
            }
        }

        return string.Join(" + ", allocation);
    }
}

public static class LoadPricingCalculator
{
    public const string ClothesCategory = "Clothes";
    public const string HouseholdTextilesCategory = "Bedsheets/Towels/Blankets";

    public static LoadPriceQuote Calculate(string category, decimal weightKg, IEnumerable<LoadPrice> prices)
    {
        if (weightKg <= 0)
            throw new ArgumentOutOfRangeException(nameof(weightKg), "Weight must be greater than zero.");
        if (weightKg > 100)
            throw new ArgumentOutOfRangeException(nameof(weightKg), "Weight cannot exceed 100 kg.");

        var tiers = prices
            .Where(price => price.Category == category)
            .OrderBy(price => price.MaxWeightKg)
            .ToArray();

        if (tiers.Length != 3 || tiers.Any(tier => tier.MaxWeightKg <= 0 || tier.Price <= 0))
            throw new InvalidOperationException($"Pricing for '{category}' must contain three valid load sizes.");

        var maxLoads = (int)Math.Ceiling(weightKg / tiers[0].MaxWeightKg);
        decimal bestPrice = decimal.MaxValue;
        decimal bestCapacity = decimal.MaxValue;
        var bestLoadCount = int.MaxValue;
        var bestCounts = new int[tiers.Length];

        for (var small = 0; small <= maxLoads; small++)
        for (var medium = 0; medium <= maxLoads - small; medium++)
        for (var large = 0; large <= maxLoads - small - medium; large++)
        {
            var counts = new[] { small, medium, large };
            var capacity = counts.Select((count, index) => count * tiers[index].MaxWeightKg).Sum();
            if (capacity < weightKg)
                continue;

            var cost = counts.Select((count, index) => count * tiers[index].Price).Sum();
            var loadCount = small + medium + large;
            if (cost > bestPrice ||
                (cost == bestPrice && loadCount > bestLoadCount) ||
                (cost == bestPrice && loadCount == bestLoadCount && capacity >= bestCapacity))
                continue;

            bestPrice = cost;
            bestCapacity = capacity;
            bestLoadCount = loadCount;
            bestCounts = counts;
        }

        return new LoadPriceQuote
        {
            Total = bestPrice,
            WeightKg = weightKg,
            Loads = tiers.Select((tier, index) =>
                (tier.LoadSize, tier.MaxWeightKg, bestCounts[index])).ToArray()
        };
    }
}
