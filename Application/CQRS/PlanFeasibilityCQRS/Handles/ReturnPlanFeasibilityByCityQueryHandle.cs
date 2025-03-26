using Application.CQRS.PlanFeasibilityCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Handles;

/*public class ReturnPlanFeasibilityByCityQueryHandle(IPlanFeasibilityRepository repository)
    : IRequestHandler<ReturnPlanFeasibilityByCityQuery, PlanFeasibility>
{
    private readonly IPlanFeasibilityRepository _repository = repository;
    
    public async Task<PlanFeasibility> Handle(ReturnPlanFeasibilityByCityQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCityAsync(request.CompanyId, request.OperatorId, request.City);
    }
}*/