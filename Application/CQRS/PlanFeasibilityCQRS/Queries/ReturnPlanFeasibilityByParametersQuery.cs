using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByParametersQuery(
    string? zipCode,
    string? city,
    string? state
    ) : IRequest<PlanFeasibility>
{
    public string? ZipCode { get; set; } = zipCode;
    public string? City { get; set; } = city;
    public string? State { get; set; } = state;
}