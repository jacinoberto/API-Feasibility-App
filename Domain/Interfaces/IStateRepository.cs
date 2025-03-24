using Domain.Entities;

namespace Domain.Interfaces;

public interface IStateRepository
{
    Task<State> GetByIdAsync(Guid id);
    Task<State> GetByUfAsync(string uf);
    Task<IEnumerable<State>> GetAllAsync();
}