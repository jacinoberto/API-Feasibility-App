namespace Application.DTOs.ViabilityRuleDTOs;

public record CreateViabilityRuleByCityDto(
    string Plan,
    int InternetSpeed,
    string SpeedType,
    decimal Value,
    string City,
    string State,
    string Observations,
    Guid CompanyId,
    Guid FeasibilityTypeId
    );