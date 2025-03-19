using Domain.Entities;

namespace Domain.Interfaces;

public interface IOperatorRepository
{
    Task CreateAsync(Operator entity);
    Task<Operator> GetByIdAsync(Guid id);
    Task<IEnumerable<Operator>> GetAllAsync();
    Task DeleteAsync(Guid id);
}