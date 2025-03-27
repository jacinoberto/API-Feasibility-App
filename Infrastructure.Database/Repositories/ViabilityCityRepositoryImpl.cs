using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ViabilityCityRepositoryImpl(AppDbContext context) : IViabilityCityRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(ViabilityCity entity)
    {
        await _context.ViabilityCities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}