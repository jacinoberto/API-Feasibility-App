using Domain.Entities;

namespace Domain.Interfaces;

public interface IInternetRepository
{
    Task CreateAsync(Internet entity);
    Task<Internet> GetByIdAsync(Guid id);
    Task<IEnumerable<Internet>> GetAllAsync();
}