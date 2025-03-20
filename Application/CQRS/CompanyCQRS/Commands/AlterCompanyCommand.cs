using Domain.Entities;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Commands;

public class AlterCompanyCommand(
    Guid id,
    string companyName,
    string responsibleEmail,
    string responsibleContact,
    string financialEmail,
    string financialContact
    ) : IRequest<Company>
{
    public Guid Id { get; set; } = id;
    public string CompanyName { get; set; } = companyName;
    public string ResponsibleEmail { get; set; } = responsibleEmail;
    public string ResponsibleContact { get; set; } = responsibleContact;
    public string FinancialEmail { get; set; } = financialEmail;
    public string FinancialContact { get; set; } = financialContact;
}