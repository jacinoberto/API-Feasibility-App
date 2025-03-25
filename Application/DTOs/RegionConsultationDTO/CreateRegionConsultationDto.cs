namespace Application.DTOs.RegionConsultationDTO;

public record CreateRegionConsultationDto(
    Guid CompanyId,
    Guid StateId
    );