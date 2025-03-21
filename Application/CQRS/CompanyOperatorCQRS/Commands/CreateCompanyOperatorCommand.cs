using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Commands;

public class CreateCompanyOperatorCommand(
    Guid companyId,
    Guid operatorId
    ) : IRequest<bool>
{
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
}