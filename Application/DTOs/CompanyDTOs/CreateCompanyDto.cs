using Domain.Utils.Validations;

namespace Application.DTOs.CompanyDTOs;

public record CreateCompanyDto(
    string CompanyName,
    string CompanyCode,
    string ResponsibleContact,
    string FinancialContact,
    string ResponsibleEmail,
    string FinancialEmail
    );