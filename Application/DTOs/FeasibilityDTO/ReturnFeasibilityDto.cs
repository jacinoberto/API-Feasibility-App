namespace Application.DTOs.FeasibilityDTO;

public record ReturnFeasibilityDto(
    Guid Id,
    string Plan,
    string Internet,
    decimal Value
    );