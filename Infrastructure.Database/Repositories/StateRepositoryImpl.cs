using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StateRepositoryImpl: IStateRepository
{
    private readonly AppDbContext _context;

    public StateRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<State> GetByIdAsync(Guid id)
    {
        return await _context.States.FindAsync(id) ??
               throw new NotFoundException("Não foi encontrado nenhum estado com o ID informado.");
    }

    public async Task<IEnumerable<State>> GetAllAsync()
    {
        return await _context.States.ToListAsync();
    }
}