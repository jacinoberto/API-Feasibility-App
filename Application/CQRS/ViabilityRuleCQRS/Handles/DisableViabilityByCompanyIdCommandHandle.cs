using Application.CQRS.ViabilityRuleCQRS.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class DisableViabilityByCompanyIdCommandHandle(IViabilityRuleRepository repository)
    : IRequestHandler<DisableViabilityByCompanyIdCommand, bool>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<bool> Handle(DisableViabilityByCompanyIdCommand request, CancellationToken cancellationToken)
    {
        await _repository.DisableAsync(request.CompanyId);
        return true;
    }
}