using Application.CQRS.PlanCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanCQRS.Handles;

public class ReturnPlanByParametersQueryHandle(IPlanRepository repository) : IRequestHandler<ReturnPlanByParametersQuery, Plan?>
{
    private readonly IPlanRepository _repository = repository;
    
    public async Task<Plan?> Handle(ReturnPlanByParametersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByParametersAsync(request.Plan, request.Value, request.InternetId);
    }
}