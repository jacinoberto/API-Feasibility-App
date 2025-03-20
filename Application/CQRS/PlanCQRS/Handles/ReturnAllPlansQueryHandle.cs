using Application.CQRS.PlanCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanCQRS.Handles;

public class ReturnAllPlansQueryHandle(IPlanRepository repository) : IRequestHandler<ReturnAllPlansQuery, IEnumerable<Plan>>
{
    private readonly IPlanRepository _repository = repository;
    
    public async Task<IEnumerable<Plan>> Handle(ReturnAllPlansQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}