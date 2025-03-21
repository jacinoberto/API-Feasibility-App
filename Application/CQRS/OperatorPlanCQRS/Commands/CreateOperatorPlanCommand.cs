using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Commands;

public class CreateOperatorPlanCommand(Guid operatorId, Guid planId) : IRequest<bool>
{
    public Guid OperatorId { get; set; } = operatorId;
    public Guid PlanId { get; set; } = planId;
}