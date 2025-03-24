using Application.CQRS.OperatorPlanCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Handles;

public class CreateOperatorPlanCommandHandle(IOperatorPlanRepository repository)
    : IRequestHandler<CreateOperatorPlanCommand, OperatorPlan>
{
    private readonly IOperatorPlanRepository _repository = repository;
    
    public async Task<OperatorPlan> Handle(CreateOperatorPlanCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new OperatorPlan(request.OperatorId, request.PlanId));
    }
}