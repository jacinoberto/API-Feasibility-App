using Application.CQRS.PlanFeasibilityCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Handles;

public class ReturnPlanFeasibilityByZipCodeQueryHandler(IPlanFeasibilityRepository repository)
    : IRequestHandler<ReturnPlanFeasibilityByZipCodeQuery, PlanFeasibility>
{
    private readonly IPlanFeasibilityRepository _repository = repository;
    
    public async Task<PlanFeasibility> Handle(ReturnPlanFeasibilityByZipCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByZipCodeAsync(request.CompanyId, request.ZipCode);
    }
}