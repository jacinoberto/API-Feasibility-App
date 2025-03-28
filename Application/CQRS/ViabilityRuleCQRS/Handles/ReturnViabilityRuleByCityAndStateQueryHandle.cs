using Application.CQRS.ViabilityRuleCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class ReturnViabilityRuleByCityAndStateQueryHandle(IViabilityRuleRepository repository)
    : IRequestHandler<ReturnViabilityRuleByCityAndStateQuery, IEnumerable<ViabilityRule>>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<IEnumerable<ViabilityRule>> Handle(ReturnViabilityRuleByCityAndStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCityAndState(request.City, request.State, request.CompanyId);
    }
}