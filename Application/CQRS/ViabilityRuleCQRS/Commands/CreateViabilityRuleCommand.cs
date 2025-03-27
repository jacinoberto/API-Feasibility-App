using Domain.Entities;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Commands;

public class CreateViabilityRuleCommand(Guid planId, Guid companyId, Guid feasibilityTypeId) : IRequest<ViabilityRule>
{
    public Guid PlanId { get; set; } = planId;
    public Guid CompanyId { get; set; } = companyId;
    public Guid FeasibilityTypeId { get; set; } = feasibilityTypeId;
}