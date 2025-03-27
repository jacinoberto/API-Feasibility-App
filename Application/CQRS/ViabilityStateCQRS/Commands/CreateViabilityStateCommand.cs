using MediatR;

namespace Application.CQRS.ViabilityStateCQRS;

public class CreateViabilityStateCommand(Guid viabilityRuleId, Guid stateId) : IRequest<bool>
{
    public Guid ViabilityRuleId { get; set; } = viabilityRuleId;
    public Guid StateId { get; set; } = stateId;
}