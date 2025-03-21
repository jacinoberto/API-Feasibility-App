using Application.CQRS.PlanCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanCQRS.Handles;

public class CreatePlanCommandHandle(IPlanRepository repository) : IRequestHandler<CreatePlanCommand, Plan>
{
    private readonly IPlanRepository _repository = repository;
    
    public async Task<Plan> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Plan(request.InternetId, request.PlanName, request.Value));
    }
}