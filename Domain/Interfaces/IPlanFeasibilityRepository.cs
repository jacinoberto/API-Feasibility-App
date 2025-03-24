using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlanFeasibilityRepository
{
    Task CreateAsync(PlanFeasibility entity);
    Task<PlanFeasibility> GetByParametersAsync(string? zipCode, string? city, string? state);
    
    Task<IEnumerable<PlanFeasibility>> GetByCityAndStateAsync(string city, string state, Guid companyId);
    Task<PlanFeasibility> GetByZipCodeAsync(Guid companyId, string zipCode);
    
    Task<PlanFeasibility> GetByCityAsync(Guid companyId, string city);
    Task<PlanFeasibility> GetByZipCodeAsync(string zipCode);
    Task<PlanFeasibility> GetByCityAsync(string city);
    Task<PlanFeasibility> GetByStateAsync(string state);
}