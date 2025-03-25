using Domain.Entities;

namespace Domain.Interfaces;

public interface IRegionConsultationRepository
{
    Task<RegionConsultation> CreateAsync(RegionConsultation entity);
    Task<IEnumerable<RegionConsultation>> GetByCompanyIdAsync(Guid companyId);
}