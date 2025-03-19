using Domain.Entities;

namespace Domain.Interfaces;

public interface IStateRepository
{
    Task<State> GetByIdAsync(Guid id);
    Task<IEnumerable<State>> GetAllAsync();
}