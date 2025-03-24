namespace Application.DTOs;

public record ReturnPlanFeasibilitDto(
    Guid Id,
    string Operator,
    string PlanName,
    string Internet,
    decimal Value
    );