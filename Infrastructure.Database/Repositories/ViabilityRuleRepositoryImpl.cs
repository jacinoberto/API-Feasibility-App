using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ViabilityRuleRepositoryImpl(AppDbContext context) : IViabilityRuleRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<ViabilityRule> CreateAsync(ViabilityRule entity)
    {
        await _context.ViabilityRules.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}