using Application.CQRS.ViabilityRuleCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class ReturnViabilityRuleByAddressQueryHandle(IViabilityRuleRepository repository)
    : IRequestHandler<ReturnViabilityRuleByAddressQuery, IEnumerable<ViabilityRule>>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<IEnumerable<ViabilityRule>> Handle(ReturnViabilityRuleByAddressQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByAddress(request.Street, request.Area, request.City, request.CompanyId);
    }
}