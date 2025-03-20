using Domain.Entities;
using MediatR;

namespace Application.CQRS.StateCQRS.Queries;

public class ReturnAllStatesQuery : IRequest<IEnumerable<State>>
{
    
}