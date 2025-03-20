using Application.CQRS.StateCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.StateCQRS.Handles;

public class ReturnAllStatesQueryHandle(IStateRepository repository) : IRequestHandler<ReturnAllStatesQuery, IEnumerable<State>>
{
    private readonly IStateRepository _repository = repository;
    
    public async Task<IEnumerable<State>> Handle(ReturnAllStatesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}