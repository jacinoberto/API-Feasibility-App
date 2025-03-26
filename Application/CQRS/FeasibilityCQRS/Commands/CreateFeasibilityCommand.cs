using Domain.Entities;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Commands;

public class CreateFeasibilityCommand(Guid operatorId, Guid addressId) : IRequest<Feasibility>
{
    public Guid OperatorId { get; set; } = operatorId;
    public Guid AddressId { get; set; } = addressId;
}