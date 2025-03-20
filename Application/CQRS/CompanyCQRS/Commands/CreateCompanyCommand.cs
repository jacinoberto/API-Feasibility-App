using Domain.Entities;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Commands;

public class CreateCompanyCommand(
    string companyName,
    string companyCode,
    string responsibleEmail,
    string financialEmail,
    string responsibleContact,
    string financialContact
    ) : IRequest<Company>
{
    public string CompanyName { get; set; } = companyName;
    public string CompanyCode { get; set; } = companyCode;
    public string ResponsibleEmail { get; set; } = responsibleEmail;
    public string ResponsibleContact { get; set; } = responsibleContact;
    public string FinancialEmail { get; set; } = financialEmail;
    public string FinancialContact { get; set; } = financialContact;
}