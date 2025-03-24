using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Commands;

public class CreateOperatorPlanCommand(Guid operatorId, Guid planId) : IRequest<OperatorPlan>
{
    public Guid OperatorId { get; set; } = operatorId;
    public Guid PlanId { get; set; } = planId;
}