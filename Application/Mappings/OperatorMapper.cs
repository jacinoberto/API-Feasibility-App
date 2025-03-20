using Application.CQRS.OperatorCQRS;
using Application.DTOs.OperatorDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class OperatorMapper
{
    public static Operator MapToOperator(CreateOperatorDto dto)
    {
        return new Operator(dto.OperatorName);
    }

    public static ReturnOperatorDto MapToReturnOperatorDto(Operator op)
    {
        return new ReturnOperatorDto(op.Id, op.OperatorName);
    }
}