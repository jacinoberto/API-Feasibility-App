using Application.CQRS.FeasibilityCQRS.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Handle;

public class ReturnFeasibilityByAddressQueryHandle(IFeasibilityRepository repository)
    : IRequestHandler<ReturnFeasibilityByAddressQuery, bool>
{
    private readonly IFeasibilityRepository _repository = repository;

    public async Task<bool> Handle(ReturnFeasibilityByAddressQuery request, CancellationToken cancellationToken)
    {
        return await _repository.CheckByAddressAsync(request.Street, request.City, request.Area, request.CompanyId, request.OperatorId);
    }
}