using Application.CQRS.PlanFeasibilityCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Handles;

public class ReturnPlanFeasibilityByCityAndStateQueryHandle(IPlanFeasibilityRepository repository)
    : IRequestHandler<ReturnPlanFeasibilityByCityAndStateQuery, IEnumerable<PlanFeasibility>>
{
    private readonly IPlanFeasibilityRepository _repository = repository;
    
    public async Task<IEnumerable<PlanFeasibility>> Handle(ReturnPlanFeasibilityByCityAndStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCityAndStateAsync(request.City, request.State, request.CompanyId, request.OperatorId);
    }
}