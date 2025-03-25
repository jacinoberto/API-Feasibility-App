namespace Application.DTOs;

public record CreatePlanFeasibilityDto(
    string Operator,
    int InternetSpeed,
    string SpeedType,
    string? ZipCode,
    string? Street,
    int? Number,
    string? Area,
    string? City,
    string? State
    );