using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanCQRS.Queries;

public class ReturnAllPlansQuery : IRequest<IEnumerable<Plan>>
{
    
}