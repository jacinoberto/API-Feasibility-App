using Domain.Entities;

namespace Domain.Interfaces;

public interface IFeasibilityTypeRepository
{
    Task<FeasibilityType> GetByIdAsync(Guid id);
    Task<IEnumerable<FeasibilityType>> GetAllAsync();
}