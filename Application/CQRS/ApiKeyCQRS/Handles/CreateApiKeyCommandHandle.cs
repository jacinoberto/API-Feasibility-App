using Application.CQRS.ApiKeyCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ApiKeyCQRS.Handles;

public class CreateApiKeyCommandHandle(IApiKeyRepository repository) : IRequestHandler<CreateApiKeyCommand, string>
{
    private readonly IApiKeyRepository _repository = repository;
    
    public async Task<string> Handle(CreateApiKeyCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new ApiKey(request.CompanyId, request.Key));
    }
}