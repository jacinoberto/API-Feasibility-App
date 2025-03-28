using Domain.Entities;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Queries;

public class ReturnViabilityRuleByCityAndStateQuery(string city, string state, Guid companyId) : IRequest<IEnumerable<ViabilityRule>>
{
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public Guid CompanyId { get; set; } = companyId;
}