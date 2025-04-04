using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlanObservationRepository
{
    Task<PlanObservation> CreateAsync(PlanObservation entity);
    Task<IEnumerable<PlanObservation>> GetByPlanIdAsync(Guid planId);
}