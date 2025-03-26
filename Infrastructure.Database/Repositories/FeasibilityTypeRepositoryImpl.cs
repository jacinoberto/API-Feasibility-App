using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FeasibilityTypeRepositoryImpl(AppDbContext context) : IFeasibilityTypeRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<IEnumerable<FeasibilityType>> GetAllAsync()
    {
        return await _context.FeasibilityTypes
            .ToListAsync();
    }
}