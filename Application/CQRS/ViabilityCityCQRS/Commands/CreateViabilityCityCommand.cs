using MediatR;

namespace Application.CQRS.ViabilityCityCQRS.Commands;

public class CreateViabilityCityCommand(Guid viabilityRuleId, Guid addressId) : IRequest<bool>
{
    public Guid ViabilityRuleId { get; set; } = viabilityRuleId;
    public Guid AddressId { get; set; } = addressId;
}