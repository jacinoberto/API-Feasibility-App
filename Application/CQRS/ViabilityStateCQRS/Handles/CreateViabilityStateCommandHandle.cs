using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityStateCQRS.Handles;

public class CreateViabilityStateCommandHandle(IViabilityStateRepository repository)
    : IRequestHandler<CreateViabilityStateCommand, bool>
{
    private readonly IViabilityStateRepository _repository = repository;
    
    public async Task<bool> Handle(CreateViabilityStateCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new ViabilityState(request.ViabilityRuleId, request.StateId));
        return true;
    }
}