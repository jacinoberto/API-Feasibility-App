namespace Application.DTOs.CompanyDTOs;

public record ReturnCompanyDto(
    Guid Id,
    string CompanyName,
    string CompanyCode,
    string ResponsibleEmail,
    string FinancialEmail,
    string ResponsibleContact,
    string FinancialContact
    );