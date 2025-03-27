namespace Application.DTOs.ViabilityRuleDTOs;

public record CreateViabilityRuleByStateDto(
    string Plan,
    int InternetSpeed,
    string SpeedType,
    decimal Value,
    string State,
    Guid CompanyId,
    Guid FeasibilityTypeId
    );