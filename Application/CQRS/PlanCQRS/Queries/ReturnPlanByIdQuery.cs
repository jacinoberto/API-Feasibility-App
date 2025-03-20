using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanCQRS.Queries;

public class ReturnPlanByIdQuery(Guid id) : IRequest<Plan>
{
    public Guid Id { get; set; } = id;
}