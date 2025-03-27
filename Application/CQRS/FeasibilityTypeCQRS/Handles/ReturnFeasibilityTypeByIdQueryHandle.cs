using Application.CQRS.FeasibilityTypeCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityTypeCQRS.Handles;

public class ReturnFeasibilityTypeByIdQueryHandle(IFeasibilityTypeRepository repository)
    : IRequestHandler<ReturnFeasibilityTypeByIdQuery, FeasibilityType>
{
    private readonly IFeasibilityTypeRepository _repository = repository;
    
    public async Task<FeasibilityType> Handle(ReturnFeasibilityTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}