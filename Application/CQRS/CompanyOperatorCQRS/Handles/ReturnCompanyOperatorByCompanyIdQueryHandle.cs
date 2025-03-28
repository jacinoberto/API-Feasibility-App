using Application.CQRS.CompanyOperatorCQRS.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Handles;

public class ReturnCompanyOperatorByCompanyIdQueryHandle(ICompanyOperatorRepository repository)
    : IRequestHandler<ReturnCompanyOperatorQuery, bool>
{
    private readonly ICompanyOperatorRepository _repository = repository;
    
    public async Task<bool> Handle(ReturnCompanyOperatorQuery request, CancellationToken cancellationToken)
    {
        return await _repository.CheckByCompanyIdAsync(request.CompanyId, request.OperatorId);
    }
}