using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ViabilityStateRepositoryImpl(AppDbContext context) : IViabilityStateRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(ViabilityState entity)
    {
        await _context.ViabilityStates.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}