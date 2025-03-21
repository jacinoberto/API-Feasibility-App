using Domain.Entities;

namespace Domain.Interfaces;

public interface IInternetRepository
{
    Task<Internet> CreateAsync(Internet entity);
    Task<Internet> GetByIdAsync(Guid id);
    
    Task<Internet> GetByInternetSpeedAsync(int internetSpeed);
    Task<IEnumerable<Internet>> GetAllAsync();
}