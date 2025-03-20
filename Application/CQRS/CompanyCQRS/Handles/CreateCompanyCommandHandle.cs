using Application.CQRS.CompanyCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Handles;

public class CreateCompanyCommandHandle(ICompanyRepository repository) : IRequestHandler<CreateCompanyCommand, Company>
{
    private readonly ICompanyRepository _repository = repository;
    
    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Company(request.CompanyName, request.CompanyCode, request.ResponsibleContact,
            request.FinancialContact, request.ResponsibleEmail, request.FinancialEmail));
    }
}