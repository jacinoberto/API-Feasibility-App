using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Queries;

public class ReturnCompanyOperatorQuery(Guid companyId, Guid operatorId) : IRequest<bool>
{
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}