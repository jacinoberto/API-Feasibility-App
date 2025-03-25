using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByCityQuery(Guid companyId, Guid operatorId, string city) : IRequest<PlanFeasibility>
{
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
    public string City { get; set; } = city;
}