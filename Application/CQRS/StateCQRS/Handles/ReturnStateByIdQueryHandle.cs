using Application.CQRS.StateCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.StateCQRS.Handles;

public class ReturnStateByIdQueryHandle(IStateRepository repository) : IRequestHandler<ReturnStateByIdQuery, State>
{
    private readonly IStateRepository _repository = repository;
    
    public async Task<State> Handle(ReturnStateByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.StateId);
    }
}