using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanObservationCQRS.Queries;

public class ReturnPlanObservationByPlanIdQuery(Guid planId) : IRequest<IEnumerable<PlanObservation>>
{
    public Guid PlanId { get; set; } = planId;
}