namespace LaundryHub.Core.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public int? UserId { get; set; }           // null = walk-in
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Address { get; set; }
    public bool IsArchived { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>Returns the last 4 digits of the phone number for guest lookup.</summary>
    public string PhoneLast4 => Phone.Length >= 4 ? Phone[^4..] : Phone;
}
