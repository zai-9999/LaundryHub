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
        decimal billableWeight = Math.Max(weightKg, MinimumWeight);
        return Math.Round(billableWeight * PricePerKilo, 2);
    }

    public override string ToString() => ServiceName;
}
