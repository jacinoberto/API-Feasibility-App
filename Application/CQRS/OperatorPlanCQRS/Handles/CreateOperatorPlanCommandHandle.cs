using Application.CQRS.OperatorPlanCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Handles;

public class CreateOperatorPlanCommandHandle(IOperatorPlanRepository repository)
    : IRequestHandler<CreateOperatorPlanCommand, bool>
{
    private readonly IOperatorPlanRepository _repository = repository;
    
    public async Task<bool> Handle(CreateOperatorPlanCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new OperatorPlan(request.OperatorId, request.PlanId));
        return true;
    }
}