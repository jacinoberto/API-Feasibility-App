namespace Application.DTOs;

public record CreatePlanFeasibilityDto(
    string Operator,
    string PlanName,
    int InternetSpeed,
    string SpeedType,
    decimal Value,
    string? ZipCode,
    string? Street,
    int? Number,
    string? Area,
    string? City,
    string? State
    );