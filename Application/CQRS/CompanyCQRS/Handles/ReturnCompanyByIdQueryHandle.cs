using Application.CQRS.CompanyCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Handles;

public class ReturnCompanyByIdQueryHandle(ICompanyRepository repository) : IRequestHandler<ReturnCompanyByIdQuery, Company>
{
    private readonly ICompanyRepository _repository = repository;
    
    public async Task<Company> Handle(ReturnCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}