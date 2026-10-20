namespace LaundryHub.Core.Models;

public class ServiceType
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public decimal PricePerKilo { get; set; }
    public decimal MinimumWeight { get; set; }
    public bool IsActive { get; set; } = true;

    /// <summary>Computes the total price given a weight in kg.</summary>
    public decimal ComputePrice(decimal weightKg)
    {
        decimal roundedWeight = Math.Round(weightKg, 2, MidpointRounding.AwayFromZero);
        decimal roundedMinWeight = Math.Round(MinimumWeight, 2, MidpointRounding.AwayFromZero);
        decimal billableWeight = Math.Max(roundedWeight, roundedMinWeight);
        return Math.Round(billableWeight * PricePerKilo, 2, MidpointRounding.AwayFromZero);
    }

    public override string ToString() => ServiceName;
}
