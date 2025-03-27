using Application.CQRS.ViabilityCityCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityCityCQRS.Handles;

public class CreateViabilityCityCommandHandle(IViabilityCityRepository repository)
    : IRequestHandler<CreateViabilityCityCommand, bool>
{
    private readonly IViabilityCityRepository _repository = repository;
    
    public async Task<bool> Handle(CreateViabilityCityCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new ViabilityCity(request.ViabilityRuleId, request.AddressId));
        return true;
    }
}