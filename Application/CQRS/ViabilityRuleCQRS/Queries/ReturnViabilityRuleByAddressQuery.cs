using Domain.Entities;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Queries;

public class ReturnViabilityRuleByAddressQuery(string street, string area, string city, Guid companyId)
    : IRequest<IEnumerable<ViabilityRule>>
{
    public string Street { get; set; } = street;
    public string Area { get; set; } = area;
    public string City { get; set; } = city;
    public Guid CompanyId { get; set; } = companyId;
}