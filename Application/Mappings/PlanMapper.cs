using Application.DTOs.PlanDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class PlanMapper
{
    public static Plan MapToPlan(CreatePlanDto dto)
    {
        return new Plan(dto.InternetId, dto.PlanName, dto.Value);
    }

    public static ReturnPlanDto MapToReturnPlanDto(Plan plan)
    {
        var internet = plan.Internet.InternetSpeed + " " + plan.Internet.SpeedType;
        
        return new ReturnPlanDto(plan.Id, plan.PlanName, internet, plan.Value);
    }
}