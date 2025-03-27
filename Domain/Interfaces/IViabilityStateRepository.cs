using Domain.Entities;

namespace Domain.Interfaces;

public interface IViabilityStateRepository
{
    Task CreateAsync(ViabilityState entity);
}