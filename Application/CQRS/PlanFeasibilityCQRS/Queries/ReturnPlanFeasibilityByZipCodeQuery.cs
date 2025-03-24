using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByZipCodeQuery(Guid companyId, string zipCode) : IRequest<PlanFeasibility>
{
    public Guid CompanyId { get; set; } = companyId;
    public string ZipCode { get; set; } = zipCode;
}