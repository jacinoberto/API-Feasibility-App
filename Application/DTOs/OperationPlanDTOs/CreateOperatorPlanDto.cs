using Application.DTOs.OperatorDTOs;
using Application.DTOs.PlanDTOs;

namespace Application.DTOs.OperationPlanDTOs;

public record CreateOperatorPlanDto(
    CreatePlanDto Plan,
    CreateOperatorDto Operator
    );