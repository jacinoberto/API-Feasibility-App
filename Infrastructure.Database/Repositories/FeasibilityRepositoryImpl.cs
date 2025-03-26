using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class FeasibilityRepositoryImpl(AppDbContext context) : IFeasibilityRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Feasibility> CreateAsync(Feasibility entity)
    {
        await _context.Feasibilities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}