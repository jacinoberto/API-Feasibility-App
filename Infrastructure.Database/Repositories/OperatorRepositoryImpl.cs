using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OperatorRepositoryImpl(AppDbContext context) : IOperatorRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(Operator entity)
    {
        await _context.Operators.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Operator> GetByIdAsync(Guid id)
    {
        return await _context.Operators.FindAsync(id)
            ?? throw new NotFoundException("Não foi entrada nenhuma operadora com esse ID.");
    }

    public async Task<IEnumerable<Operator>> GetAllAsync()
    {
        return await _context.Operators
                   .Where(op => op.IsActive == true)
                   .ToListAsync() 
               ?? throw new NotFoundException("Não há operadoras cadastradas no sistema ou todas foram desativadas.");
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        entity.DeactivateOperator();
        await _context.SaveChangesAsync();
    }
}