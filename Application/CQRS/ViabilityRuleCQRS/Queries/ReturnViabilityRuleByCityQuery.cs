using Domain.Entities;
using MediatR;

namespace Application.CQRS.ViabilityRuleCQRS.Queries;

public class ReturnViabilityRuleByCityQuery(string city, Guid companyId) : IRequest<ICollection<ViabilityRule>>
{
    public string City { get; set; } = city;
    public Guid CompanyId { get; set; } = companyId;
}