using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByCityQuery(Guid companyId, string city) : IRequest<PlanFeasibility>
{
    public Guid CompanyId { get; set; } = companyId;
    public string City { get; set; } = city;
}