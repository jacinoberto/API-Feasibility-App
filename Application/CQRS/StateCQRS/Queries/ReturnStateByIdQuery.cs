using Domain.Entities;
using MediatR;

namespace Application.CQRS.StateCQRS.Queries;

public class ReturnStateByIdQuery : IRequest<State>
{
    public Guid StateId { get; set; }

    public ReturnStateByIdQuery(Guid stateId)
    {
        StateId = stateId;
    }
}