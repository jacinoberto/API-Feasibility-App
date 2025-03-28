using Application.CQRS.FeasibilityCQRS.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Handle;

public class ReturnFeasibilityByZipCodeQueryHandle(IFeasibilityRepository repository)
    : IRequestHandler<ReturnFeasibilityByZipCodeQuery, bool>
{
    private readonly IFeasibilityRepository _repository = repository;
    
    public async Task<bool> Handle(ReturnFeasibilityByZipCodeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.CheckByZipCodeAsync(request.ZipCode, request.CompanyId, request.OperatorId);
    }
}