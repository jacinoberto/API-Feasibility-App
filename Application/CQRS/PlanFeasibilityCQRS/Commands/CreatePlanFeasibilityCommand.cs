using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Commands;

public class CreatePlanFeasibilityCommand(Guid planOperatorId, Guid addressId) : IRequest<bool>
{
    public Guid PlanOperatorId { get; set; } = planOperatorId;
    public Guid AddressId { get; set; } = addressId;
}