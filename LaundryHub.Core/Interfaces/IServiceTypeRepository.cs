using LaundryHub.Core.Models;

namespace LaundryHub.Core.Interfaces;

public interface IServiceTypeRepository
{
    IEnumerable<ServiceType> GetAll(bool activeOnly = true);
    ServiceType? GetById(int serviceId);
    void Add(ServiceType service);
    void Update(ServiceType service);
    void SetActive(int serviceId, bool isActive);
    bool NameExists(string serviceName, int excludeServiceId = 0);
}
