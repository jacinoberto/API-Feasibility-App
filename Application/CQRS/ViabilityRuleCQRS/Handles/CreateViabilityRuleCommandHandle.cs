using Application.CQRS.ViabilityRuleCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class CreateViabilityRuleCommandHandle(IViabilityRuleRepository repository)
    : IRequestHandler<CreateViabilityRuleCommand, ViabilityRule>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<ViabilityRule> Handle(CreateViabilityRuleCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new ViabilityRule(request.PlanId, request.CompanyId, request.FeasibilityTypeId));
    }
}