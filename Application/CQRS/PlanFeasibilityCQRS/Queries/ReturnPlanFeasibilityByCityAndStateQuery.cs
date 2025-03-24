using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByCityAndStateQuery(string city, string state, Guid companyId)
    : IRequest<IEnumerable<PlanFeasibility>>
{
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public Guid CompanyId { get; set; } = companyId;
}