namespace Application.DTOs.PlanDTOs;

public record ReturnPlanDto(
    Guid Id,
    string PlanName,
    string Internet,
    decimal Value
    );