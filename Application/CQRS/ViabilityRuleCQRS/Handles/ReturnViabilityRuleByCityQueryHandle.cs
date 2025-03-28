using Application.CQRS.ViabilityRuleCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Handles;

public class ReturnViabilityRuleByCityQueryHandle(IViabilityRuleRepository repository)
    : IRequestHandler<ReturnViabilityRuleByCityQuery, ICollection<ViabilityRule>>
{
    private readonly IViabilityRuleRepository _repository = repository;
    
    public async Task<ICollection<ViabilityRule>> Handle(ReturnViabilityRuleByCityQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCity(request.City, request.CompanyId);
    }
}