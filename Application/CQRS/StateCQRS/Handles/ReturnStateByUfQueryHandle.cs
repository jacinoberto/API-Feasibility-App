using Application.CQRS.StateCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.StateCQRS.Handles;

public class ReturnStateByUfQueryHandle(IStateRepository repository) : IRequestHandler<ReturnStateByUfQuery, State>
{
    private readonly IStateRepository _repository = repository;
    
    public async Task<State> Handle(ReturnStateByUfQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByUfAsync(request.Uf);
    }
}