using Application.CQRS.ApiKeyCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Handles;

public class ReturnApiKeyByKeyQueryHandle(IApiKeyRepository repository) : IRequestHandler<ReturnApiKeyByKeyQuery, ApiKey>
{
    private readonly IApiKeyRepository _repository = repository;
    
    public async Task<ApiKey> Handle(ReturnApiKeyByKeyQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetApiKeyAsync(request.Key);
    }
}