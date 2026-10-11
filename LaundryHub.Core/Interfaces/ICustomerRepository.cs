using LaundryHub.Core.Models;

namespace LaundryHub.Core.Interfaces;

public interface ICustomerRepository
{
    Customer? GetById(int customerId);
    Customer? GetByUserId(int userId);
    IEnumerable<Customer> Search(string term);
    IEnumerable<Customer> GetAll(bool includeArchived = false);
    int Add(Customer customer);
    void Update(Customer customer);
    void Archive(int customerId);
    void Restore(int customerId);
    bool PhoneExists(string phone, int excludeCustomerId = 0);
}
