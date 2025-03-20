using Application.DTOs.CompanyDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class CompanyMapper
{
    public static Company MapToCompany(CreateCompanyDto dto)
    {
        return new Company(dto.CompanyName, dto.CompanyCode, dto.ResponsibleContact, dto.FinancialContact,
            dto.ResponsibleEmail, dto.FinancialEmail);
    }

    public static ReturnCompanyDto MapToReturnCompanyDto(Company company)
    {
        return new ReturnCompanyDto(company.Id, company.CompanyName, company.CompanyCode, company.ResponsibleEmail,
            company.FinancialEmail, company.ResponsibleContact, company.FinancialContact);
    }
}