using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Queries;

public class ReturnFeasibilityByZipCodeQuery(string zipCode, Guid companyId, Guid operatorId) : IRequest<bool>
{
    public string ZipCode { get; set; } = zipCode;
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}