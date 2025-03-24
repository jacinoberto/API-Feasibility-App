using Domain.Entities;

namespace Domain.Interfaces;

public interface IApiKeyRepository
{
    Task<string> CreateAsync(ApiKey apiKey);
    Task<ApiKey> GetApiKeyAsync(string apiKey);
    Task<bool> IsValidApiKeyAsync(string apiKey);
}