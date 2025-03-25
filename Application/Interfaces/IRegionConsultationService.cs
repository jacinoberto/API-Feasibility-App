using Application.DTOs.RegionConsultationDTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface IRegionConsultationService
{
    Task CreateAllAsync(IEnumerable<CreateRegionConsultationDto> dtos);
    Task<IEnumerable<ReturnRegionConsultationDto>> GetByCompanyIdAsync(Guid companyId);
}