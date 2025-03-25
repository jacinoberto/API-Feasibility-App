namespace Application.Interfaces;

public interface IApiKeyService
{
    Task<string> CreateApiKeyAsync(Guid companyId);
    Task<bool> ValidateApiKeyAsync(string key);
    Task<Guid> GetCompanyIdFromApiKeyAsync(string key);
}