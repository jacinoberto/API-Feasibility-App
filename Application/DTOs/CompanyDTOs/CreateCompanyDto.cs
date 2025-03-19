using Domain.Utils.Validations;

namespace Application.DTOs.CompanyDTOs;

public record CreateCompanyDto(
    string CompanyName,
    [CompanyCode(ErrorMessage = "O CNPJ é invalido.")]
    string CompanyCode,
    string ResponsibleContact,
    string FinancialContact,
    string ResponsibleEmail,
    string FinancialEmail
    );