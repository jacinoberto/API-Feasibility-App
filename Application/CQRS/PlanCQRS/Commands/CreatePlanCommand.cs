using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanCQRS.Commands;

public class CreatePlanCommand(
    Guid internetId,
    string planName,
    decimal value
    ) : IRequest<Plan>
{
    public Guid InternetId { get; set; } = internetId;
    public string PlanName { get; set; } = planName;
    public decimal Value { get; set; } = value;
}