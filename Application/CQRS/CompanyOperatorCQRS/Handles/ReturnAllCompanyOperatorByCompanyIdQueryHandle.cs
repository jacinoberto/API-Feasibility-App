using Application.CQRS.CompanyOperatorCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Handles;

public class ReturnAllCompanyOperatorByCompanyIdQueryHandle(ICompanyOperatorRepository repository)
    : IRequestHandler<ReturnAllCompanyOperatorByCompanyIdQuery, IEnumerable<CompanyOperator>>
{
    private readonly ICompanyOperatorRepository _repository = repository;
    
    public async Task<IEnumerable<CompanyOperator>> Handle(ReturnAllCompanyOperatorByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllByCompanyIdAsync(request.CompanyId);
    }
}