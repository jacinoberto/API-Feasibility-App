using Domain.Entities;

namespace Domain.Interfaces;

public interface IViabilityCityRepository
{
    Task CreateAsync(ViabilityCity entity);
}