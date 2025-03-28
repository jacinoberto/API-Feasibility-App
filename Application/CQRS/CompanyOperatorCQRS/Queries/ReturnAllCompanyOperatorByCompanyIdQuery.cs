using Domain.Entities;
using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Queries;

public class ReturnAllCompanyOperatorByCompanyIdQuery(Guid companyId) : IRequest<IEnumerable<CompanyOperator>>
{
    public Guid CompanyId { get; set; } = companyId;
}