using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InternetRepositoryImpl(AppDbContext context) : IInternetRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(Internet entity)
    {
        await _context.Internets.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Internet> GetByIdAsync(Guid id)
    {
        return await _context.Internets.FindAsync(id)
            ?? throw new NotFoundException("Não foi encontrada nenhuma internet com o ID informado.");
    }

    public async Task<IEnumerable<Internet>> GetAllAsync()
    {
        return await _context.Internets.ToListAsync();
    }
}