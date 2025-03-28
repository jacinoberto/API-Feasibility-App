using Domain.Entities;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Queries;

public class ReturnViabilityRuleByZipCodeQuery(string zipCode, Guid companyId) : IRequest<IEnumerable<ViabilityRule>>
{
    public string ZipCode { get; set; } = zipCode;
    public Guid CompanyId { get; set; } = companyId;
}