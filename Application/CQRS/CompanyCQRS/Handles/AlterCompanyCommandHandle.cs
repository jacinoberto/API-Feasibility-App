using Application.CQRS.CompanyCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Handles;

public class AlterCompanyCommandHandle(ICompanyRepository repository) : IRequestHandler<AlterCompanyCommand, Company>
{
    private readonly ICompanyRepository _repository = repository;
    
    public async Task<Company> Handle(AlterCompanyCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(request.Id, new Company(request.CompanyName, null, request.ResponsibleContact,
            request.FinancialContact, request.ResponsibleEmail, request.FinancialEmail));
    }
}