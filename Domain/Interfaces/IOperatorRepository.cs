using Domain.Entities;

namespace Domain.Interfaces;

public interface IOperatorRepository
{
    Task<Operator> CreateAsync(Operator entity);
    Task<Operator> GetByIdAsync(Guid id);
    Task<Operator?> GetByNameAsync(string operatorName);
    Task<IEnumerable<Operator>> GetAllAsync();
    Task DeleteAsync(Guid id);
}