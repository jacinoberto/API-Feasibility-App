using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InternetRepositoryImpl(AppDbContext context) : IInternetRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Internet> CreateAsync(Internet entity)
    {
        await _context.Internets.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Internet> GetByIdAsync(Guid id)
    {
        return await _context.Internets.FindAsync(id)
            ?? throw new NotFoundException("Não foi encontrada nenhuma internet com o ID informado.");
    }

    public async Task<Internet?> GetByInternetSpeedAsync(int internetSpeed)
    {
        return await _context.Internets
            .FirstOrDefaultAsync(i => i.InternetSpeed == internetSpeed);
    }

    public async Task<IEnumerable<Internet>> GetAllAsync()
    {
        return await _context.Internets.ToListAsync();
    }
}