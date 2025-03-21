using Application.DTOs.OperatorDTOs;
using Application.DTOs.PlanDTOs;

namespace Application.DTOs.OperationPlanDTOs;

public record CreateOperatorPlanDto(
    string PlanName,
    int InternetSpeed,
    string SpeedType,
    decimal Value,
    CreateOperatorDto Operator
    );