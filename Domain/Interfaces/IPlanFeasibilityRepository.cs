using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlanFeasibilityRepository
{
    Task CreateAsync(PlanFeasibility entity);
    Task<PlanFeasibility> GetByParametersAsync(string? zipCode, string? city, string? state);
    
    Task<PlanFeasibility> GetByCityAndStateAsync(string city, string state);
    Task<PlanFeasibility> GetByZipCodeAsync(string zipCode);
    Task<PlanFeasibility> GetByCityAsync(string city);
    Task<PlanFeasibility> GetByStateAsync(string state);
}