using Application.CQRS.PlanFeasibilityCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Handles;

public class ReturnPlanFeasibilityByParametersQueryHandler(IPlanFeasibilityRepository repository)
    : IRequestHandler<ReturnPlanFeasibilityByParametersQuery, PlanFeasibility>
{
    private readonly IPlanFeasibilityRepository _repository = repository;
    
    public async Task<PlanFeasibility> Handle(ReturnPlanFeasibilityByParametersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByParametersAsync(request.ZipCode, request.City, request.State);
    }
}