using Application.CQRS.PlanFeasibilityCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Handles;

public class CreatePlanFeasibilityCommandHandle(IPlanFeasibilityRepository repository)
    : IRequestHandler<CreatePlanFeasibilityCommand, bool>
{
    private readonly IPlanFeasibilityRepository _repository = repository;
    
    public async Task<bool> Handle(CreatePlanFeasibilityCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new PlanFeasibility(request.PlanOperatorId, request.AddressId));
        return true;
    }
}