using Domain.Entities;
using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Queries;

public class ReturnApiKeyByKeyQuery(string key) : IRequest<ApiKey>
{
    public string Key { get; set; } = key;
}