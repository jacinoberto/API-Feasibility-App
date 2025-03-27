namespace Application.DTOs.ViabilityRuleDTOs;

public record CreateViabilityRuleByCityDto(
    string Plan,
    int InternetSpeed,
    string SpeedType,
    decimal Value,
    string City,
    string State,
    Guid CompanyId,
    Guid FeasibilityTypeId
    );