using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Commands;

public class DisableViabilityByCompanyIdCommand(Guid companyId) : IRequest<bool>
{
    public Guid CompanyId { get; set; } = companyId;
}