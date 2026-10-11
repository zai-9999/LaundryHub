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
    void UpdateStatus(int orderId, string newStatus, string? cancelReason = null);
    void RecordPayment(int orderId, decimal amountPaid);
    void Archive(int orderId);
    string GenerateOrderNumber();
    DailyReport GetDailyReport(DateTime date);
}
