using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Queries;

public class ReturnOperatorPlanByOperatorIdQuery(Guid operatorId)
    : IRequest<IEnumerable<OperatorPlan>>
{
    public Guid OperatorId { get; set; } = operatorId;
}