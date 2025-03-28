using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Queries;

public class ReturnFeasibilityByCityQuery(string city, Guid companyId, Guid operatorId) : IRequest<bool>
{
    public string City { get; set; } = city;
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}