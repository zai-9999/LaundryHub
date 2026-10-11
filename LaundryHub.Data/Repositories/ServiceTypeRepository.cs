using Dapper;
using LaundryHub.Core.Interfaces;
using LaundryHub.Core.Models;

namespace LaundryHub.Data.Repositories;

public class ServiceTypeRepository : IServiceTypeRepository
{
    private readonly DbContext _db;

    public ServiceTypeRepository(DbContext db) => _db = db;

    public IEnumerable<ServiceType> GetAll(bool activeOnly = true)
    {
        using var conn = _db.CreateConnection();
        var sql = activeOnly
            ? "SELECT * FROM service_types WHERE is_active = TRUE ORDER BY service_name"
            : "SELECT * FROM service_types ORDER BY service_name";
        return conn.Query<ServiceType>(sql);
    }

    public ServiceType? GetById(int serviceId)
    {
        using var conn = _db.CreateConnection();
        return conn.QueryFirstOrDefault<ServiceType>(
            "SELECT * FROM service_types WHERE service_id = @ServiceId",
            new { ServiceId = serviceId });
    }

    public void Add(ServiceType service)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            INSERT INTO service_types (service_name, price_per_kilo, minimum_weight)
            VALUES (@ServiceName, @PricePerKilo, @MinimumWeight)",
            service);
    }

    public void Update(ServiceType service)
    {
        using var conn = _db.CreateConnection();
        conn.Execute(@"
            UPDATE service_types
            SET service_name = @ServiceName, price_per_kilo = @PricePerKilo,
                minimum_weight = @MinimumWeight
            WHERE service_id = @ServiceId",
            service);
    }

    public void SetActive(int serviceId, bool isActive)
    {
        using var conn = _db.CreateConnection();
        conn.Execute("UPDATE service_types SET is_active = @IsActive WHERE service_id = @ServiceId",
            new { IsActive = isActive, ServiceId = serviceId });
    }
}
