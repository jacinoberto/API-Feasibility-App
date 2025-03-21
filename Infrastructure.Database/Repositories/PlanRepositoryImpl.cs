using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlanRepositoryImpl(AppDbContext context) : IPlanRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Plan> CreateAsync(Plan entity)
    {
        await _context.Plans.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Plan> GetByIdAsync(Guid id)
    {
        return await _context.Plans
                   .Include(plan => plan.Internet)
                   .SingleOrDefaultAsync(plan => plan.Id == id)
            ?? throw new NotFoundException("Não foi entrado nenhum plano com o ID informado.");
    }

    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await _context.Plans
                   .Where(plan => plan.IsActive == true)
                   .Include(plan => plan.Internet)
                   .ToListAsync()
               ?? throw new NotFoundException("Não há planos cadastrados no sistema ou todos foram desativados.");
    }

    public async Task DeleteAsync(Guid id)
    {
        var plan = await GetByIdAsync(id);
        plan.DeactivatePlan();
        await _context.SaveChangesAsync();
    }
}