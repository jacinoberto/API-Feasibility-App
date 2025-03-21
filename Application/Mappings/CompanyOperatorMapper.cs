using Application.DTOs.CompanyOperatorDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class CompanyOperatorMapper
{
    public static ReturnCompanyOperatorDto MapToReturnCompanyOperatorDto(CompanyOperator entity)
    {
        return new ReturnCompanyOperatorDto(entity.Operator.OperatorName);
    }
}