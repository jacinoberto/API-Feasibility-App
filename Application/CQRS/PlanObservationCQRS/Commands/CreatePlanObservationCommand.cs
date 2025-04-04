using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanObservationCQRS.Commands;

public class CreatePlanObservationCommand(Guid planId, Guid observationId) : IRequest<PlanObservation>
{
    public Guid PlanId { get; set; } = planId;
    public Guid ObservationId { get; set; } = observationId;
}