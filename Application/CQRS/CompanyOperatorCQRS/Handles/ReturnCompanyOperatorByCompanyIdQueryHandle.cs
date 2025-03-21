using Application.CQRS.CompanyOperatorCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Handles;

public class ReturnCompanyOperatorByCompanyIdQueryHandle(ICompanyOperatorRepository repository)
    : IRequestHandler<ReturnCompanyOperatorByCompanyIdQuery, IEnumerable<CompanyOperator>>
{
    private readonly ICompanyOperatorRepository _repository = repository;
    
    public async Task<IEnumerable<CompanyOperator>> Handle(ReturnCompanyOperatorByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCompanyIdAsync(request.CompanyId);
    }
}