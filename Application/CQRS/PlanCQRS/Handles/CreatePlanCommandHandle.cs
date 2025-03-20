using Application.CQRS.PlanCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanCQRS.Handles;

public class CreatePlanCommandHandle(IPlanRepository repository) : IRequestHandler<CreatePlanCommand, bool>
{
    private readonly IPlanRepository _repository = repository;
    
    public async Task<bool> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Plan(request.InternetId, request.PlanName, request.Value));
        return true;
    }
}