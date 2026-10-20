namespace LaundryHub.Core.Enums;

public enum OrderStatus
{
    Washing,
    Drying,
    ReadyForPickup,
    Claimed,
    Cancelled
}

public static class OrderStatusExtensions
{
    public static string ToDisplayString(this OrderStatus status) => status switch
    {
        OrderStatus.Washing        => "Washing",
        OrderStatus.Drying         => "Drying",
        OrderStatus.ReadyForPickup => "Ready for Pickup",
        OrderStatus.Claimed        => "Claimed",
        OrderStatus.Cancelled      => "Cancelled",
        _                          => status.ToString()
    };

    public static OrderStatus? Next(this OrderStatus status) => status switch
    {
        OrderStatus.Washing        => OrderStatus.Drying,
        OrderStatus.Drying         => OrderStatus.ReadyForPickup,
        OrderStatus.ReadyForPickup => OrderStatus.Claimed,
        _                          => null
    };

    public static bool IsFinal(this OrderStatus status) =>
        status == OrderStatus.Claimed || status == OrderStatus.Cancelled;
}
