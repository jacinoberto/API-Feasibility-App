using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Queries;

public class IsValidApiKeyQuery(string key) : IRequest<bool>
{
    public string Key { get; set; } = key;
}