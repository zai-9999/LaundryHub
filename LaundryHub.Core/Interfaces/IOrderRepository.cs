using LaundryHub.Core.Models;

namespace LaundryHub.Core.Interfaces;

public interface IOrderRepository
{
    Order? GetById(int orderId);
    Order? GetByOrderNumber(string orderNumber);
    IEnumerable<Order> GetAll(bool includeArchived = false);
    IEnumerable<Order> GetByCustomer(int customerId);
    IEnumerable<Order> GetByDate(DateTime date);
    IEnumerable<Order> Search(string term);
    int Add(Order order);
    bool ConfirmDropOff(int orderId);
    bool UpdateConfirmedWeight(int orderId, decimal weightKg, decimal totalAmount);
    void UpdateStatus(int orderId, string newStatus, string? cancelReason = null, int? changedBy = null, string? notes = null);
    void RecordPayment(int orderId, decimal amountPaid);
    void ClaimOrderWithPayment(int orderId, decimal amountPaid, int? changedBy = null, string? notes = null);
    bool RequestCancellation(int orderId, int customerId, string reason);
    bool ApproveCancellationRequest(int orderId, int? changedBy = null);
    bool RejectCancellationRequest(int orderId, int? changedBy = null);
    void Archive(int orderId);
    string GenerateOrderNumber();
    DailyReport GetDailyReport(DateTime date);
}
