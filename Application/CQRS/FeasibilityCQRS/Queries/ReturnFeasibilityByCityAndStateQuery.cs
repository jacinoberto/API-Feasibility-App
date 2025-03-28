using Domain.Entities;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Queries;

public class ReturnFeasibilityByCityAndStateQuery(string city, string state, Guid companyId, Guid operatorId)
    : IRequest<bool>
{
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}