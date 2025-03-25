using Domain.Entities;
using MediatR;

namespace Application.CQRS.RegionConsultationCQRS.Commands;

public class CreateRegionConsultationCommand(Guid companyId, Guid stateId) : IRequest<RegionConsultation>
{
    public Guid CompanyId { get; set; } = companyId;
    public Guid StateId { get; set; } = stateId;
}