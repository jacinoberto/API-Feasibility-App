using Application.CQRS.FeasibilityCQRS.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Handle;

public class ReturnFeasibilityByCityQueryHandle(IFeasibilityRepository repository)
    : IRequestHandler<ReturnFeasibilityByCityQuery, bool>
{
    private readonly IFeasibilityRepository _repository = repository;
    
    public async Task<bool> Handle(ReturnFeasibilityByCityQuery request, CancellationToken cancellationToken)
    {
        return await _repository.CheckByCityAsync(request.City, request.CompanyId, request.OperatorId);
    }
}