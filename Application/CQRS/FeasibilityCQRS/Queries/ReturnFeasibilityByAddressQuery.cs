using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Queries;

public class ReturnFeasibilityByAddressQuery(string street, string city, string area, Guid companyId, Guid operatorId)
    : IRequest<bool>
{
    public string Street { get; set; } = street;
    public string City { get; set; } = city;
    public string Area { get; set; } = area;
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}