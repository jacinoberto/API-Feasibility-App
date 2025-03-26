using Domain.Entities;

namespace Domain.Interfaces;

public interface IFeasibilityRepository
{
    Task<Feasibility> CreateAsync(Feasibility entity);
}