namespace LaundryHub.Core.Models;

public class DailyReport
{
    public DateTime ReportDate { get; set; } = DateTime.Today;
    public int TotalOrders { get; set; }
    public int PendingOrders { get; set; }    // not yet Claimed/Cancelled
    public int ClaimedOrders { get; set; }
    public int CancelledOrders { get; set; }
    public decimal TotalSales { get; set; }   // sum of Claimed order amounts
    public List<Order> Orders { get; set; } = new();
}
