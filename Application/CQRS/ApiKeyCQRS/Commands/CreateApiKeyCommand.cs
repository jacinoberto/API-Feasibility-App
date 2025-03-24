using Domain.Entities;
using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Commands;

public class CreateApiKeyCommand(
    Guid companyId,
    string key
    ) : IRequest<string>
{
    public Guid CompanyId { get; set; } = companyId;
    public string Key { get; set; } = key;
}