using Domain.Entities;

namespace Domain.Interfaces;

public interface IObservationRepository
{
    Task<Observation> CreateAsync(Observation entity);
}