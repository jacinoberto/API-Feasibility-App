namespace Application.DTOs.FeasibilityDTO;

public record CreateFeasibilityDto(
    string Operator,
    string? ZipCode,
    string? Street,
    int? Number,
    string? Area,
    string? City,
    string? State
    );