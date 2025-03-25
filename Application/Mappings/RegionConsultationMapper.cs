using Application.DTOs.RegionConsultationDTO;
using Domain.Entities;

namespace Application.Mappings;

public static class RegionConsultationMapper
{
    public static ReturnRegionConsultationDto MapToReturnRegionConsultationDto(RegionConsultation entity)
    {
        return new ReturnRegionConsultationDto(entity.Id, entity.State.Uf);
    }
}