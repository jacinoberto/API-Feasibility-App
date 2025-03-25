using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class PlanFeasibilityMapper
{
    public static ReturnPlanFeasibilitDto MapToReturnPlanFeasibilityDto(this PlanFeasibility planFeasibility)
    {
        var internet = planFeasibility.OperatorPlan.Plan.Internet.InternetSpeed + " " + planFeasibility.OperatorPlan.Plan.Internet.SpeedType;
        
        return new ReturnPlanFeasibilitDto(planFeasibility.Id, planFeasibility.OperatorPlan.Operator.OperatorName, internet);
    }
}