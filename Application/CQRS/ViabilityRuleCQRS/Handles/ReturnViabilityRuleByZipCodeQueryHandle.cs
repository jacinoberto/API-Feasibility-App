using Application.CQRS.ViabilityRuleCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class ReturnViabilityRuleByZipCodeQueryHandle(IViabilityRuleRepository repository) 
    : IRequestHandler<ReturnViabilityRuleByZipCodeQuery, IEnumerable<ViabilityRule>>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<IEnumerable<ViabilityRule>> Handle(ReturnViabilityRuleByZipCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByZipCode(request.ZipCode, request.CompanyId);
    }
}