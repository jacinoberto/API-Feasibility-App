using Application.CQRS.FeasibilityTypeCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityTypeCQRS.Handles;

public class ReturnAllFeasibilityTypeQueryHandle(IFeasibilityTypeRepository repository)
    : IRequestHandler<ReturnAllFeasibilityTypeQuery, IEnumerable<FeasibilityType>>
{
    private readonly IFeasibilityTypeRepository _repository = repository;
    
    public async Task<IEnumerable<FeasibilityType>> Handle(ReturnAllFeasibilityTypeQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}