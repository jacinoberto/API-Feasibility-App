using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FeasibilityTypeRepositoryImpl(AppDbContext context) : IFeasibilityTypeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<FeasibilityType> GetByIdAsync(Guid id)
    {
        return await _context.FeasibilityTypes.FindAsync(id)
            ?? throw new NotFoundException("Não foi encontrato nenhum tipo de viabilidade com o ID informado!");
    }

    public async Task<IEnumerable<FeasibilityType>> GetAllAsync()
    {
        return await _context.FeasibilityTypes
            .ToListAsync();
    }
}