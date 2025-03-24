using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApiKeyRepositoryImpl(AppDbContext context) : IApiKeyRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<string> CreateAsync(ApiKey apiKey)
    {
        await _context.ApiKeys.AddAsync(apiKey);
        await _context.SaveChangesAsync();
        return apiKey.Key;
    }

    public async Task<ApiKey> GetApiKeyAsync(string apiKey)
    {
        return await _context.ApiKeys.FirstOrDefaultAsync(key => key.Key == apiKey && key.IsActive == true)
            ?? throw new NotFoundException("Chave de API não encontrada.");
    }

    public async Task<bool> IsValidApiKeyAsync(string apiKey)
    {
        return await _context.ApiKeys.AnyAsync(key => key.Key == apiKey && key.IsActive == true);
    }
}