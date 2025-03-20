using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Queries;

public class ReturnAllOperatorQuery : IRequest<IEnumerable<Operator>>
{
    
}