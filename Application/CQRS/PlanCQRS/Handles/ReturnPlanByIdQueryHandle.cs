using Application.CQRS.PlanCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanCQRS.Handles;

public class ReturnPlanByIdQueryHandle(IPlanRepository repository) : IRequestHandler<ReturnPlanByIdQuery, Plan>
{
    private readonly IPlanRepository _repository = repository;
    
    public async Task<Plan> Handle(ReturnPlanByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}