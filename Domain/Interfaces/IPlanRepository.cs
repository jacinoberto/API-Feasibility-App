using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlanRepository
{
    Task<Plan> CreateAsync(Plan entity);
    Task<Plan> GetByIdAsync(Guid id);
    Task<Plan?> GetByParametersAsync(string plan, decimal value, Guid internetId);
    Task<IEnumerable<Plan>> GetAllAsync();
    Task DeleteAsync(Guid id);
}