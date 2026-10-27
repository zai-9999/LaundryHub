namespace LaundryHub.Core.Models;

public class Order
{
    public int OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    public string LaundryCategory { get; set; } = LoadPricingCalculator.ClothesCategory;
    public decimal WeightKg { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Washing";
    public string? CancelReason { get; set; }
    public string? CancelRequestStatus { get; set; }
    public string? CancelRequestReason { get; set; }
    public DateTime? CancelRequestedAt { get; set; }
    public bool PaymentRecorded { get; set; } = false;
    public decimal? AmountPaid { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? PickupDate { get; set; }
    public DateTime? ClaimedAt { get; set; }
    public bool IsArchived { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation (joined from queries)
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? ServiceName { get; set; }
    public string? CreatedByName { get; set; }
}
