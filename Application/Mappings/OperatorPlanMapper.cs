using Application.DTOs.OperationPlanDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class OperatorPlanMapper
{
    public static ReturnOperatorPlanDto MapToReturnOperatorPlanDto(OperatorPlan entity)
    {
        var internet = entity.Plan.Internet.InternetSpeed + " " + entity.Plan.Internet.SpeedType;
        
        return new ReturnOperatorPlanDto(entity.Id, entity.Operator.OperatorName, entity.Plan.PlanName, internet,
            entity.Plan.Value);
    }
}