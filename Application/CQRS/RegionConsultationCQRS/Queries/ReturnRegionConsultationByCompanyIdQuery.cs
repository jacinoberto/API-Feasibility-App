using Domain.Entities;
using MediatR;

namespace Application.CQRS.RegionConsultationCQRS.Queries;

public class ReturnRegionConsultationByCompanyIdQuery(Guid companyId) : IRequest<IEnumerable<RegionConsultation>>
{
    public Guid CompanyId { get; set; } = companyId;
}