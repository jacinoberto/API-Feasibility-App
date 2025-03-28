using Application.CQRS.AddressCQRS.Queries;
using Application.CQRS.FeasibilityCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Handle;

public class ReturnFeasibilityByCityAndStateQueryHandle(IFeasibilityRepository repository)
    : IRequestHandler<ReturnFeasibilityByCityAndStateQuery, bool>
{
    private readonly IFeasibilityRepository _repository = repository;
    
    public async Task<bool> Handle(ReturnFeasibilityByCityAndStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.CheckByCityAndStateAsync(request.City, request.State, request.CompanyId,
            request.OperatorId);
    }
}