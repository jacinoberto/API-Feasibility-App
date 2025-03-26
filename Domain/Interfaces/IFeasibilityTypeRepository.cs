using Domain.Entities;

namespace Domain.Interfaces;

public interface IFeasibilityTypeRepository
{
    Task<IEnumerable<FeasibilityType>> GetAllAsync();
}