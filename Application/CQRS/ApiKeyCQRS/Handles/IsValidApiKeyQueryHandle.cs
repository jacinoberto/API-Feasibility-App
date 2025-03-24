using Application.CQRS.ApiKeyCQRS.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Handles;

public class IsValidApiKeyQueryHandle(IApiKeyRepository repository) : IRequestHandler<IsValidApiKeyQuery, bool>
{
    private readonly IApiKeyRepository _repository = repository;
    
    public async Task<bool> Handle(IsValidApiKeyQuery request, CancellationToken cancellationToken)
    {
        return await _repository.IsValidApiKeyAsync(request.Key);
    }
}