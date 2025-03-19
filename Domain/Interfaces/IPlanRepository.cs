using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlanRepository
{
    Task CreateAsync(Plan entity);
    Task<Plan> GetByIdAsync(Guid id);
    Task<IEnumerable<Plan>> GetAllAsync();
    Task DeleteAsync(Guid id);
}