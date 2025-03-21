using Application.CQRS.OperatorPlanCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorPlanCQRS.Handles;

public class ReturnOperatorPlanByOperatorIdQueryHandle(IOperatorPlanRepository repository)
    : IRequestHandler<ReturnOperatorPlanByOperatorIdQuery, IEnumerable<OperatorPlan>>
{
    private readonly IOperatorPlanRepository _repository = repository;
    
    public async Task<IEnumerable<OperatorPlan>> Handle(ReturnOperatorPlanByOperatorIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByOperatorIdAsync(request.OperatorId);
    }
}