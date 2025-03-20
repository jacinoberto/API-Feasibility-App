namespace Application.DTOs.PlanDTOs;

public record CreatePlanDto(
    Guid InternetId,
    string PlanName,
    decimal Value
    );