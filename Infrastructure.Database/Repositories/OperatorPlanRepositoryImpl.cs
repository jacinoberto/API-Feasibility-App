using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OperatorPlanRepositoryImpl(AppDbContext context) : IOperatorPlanRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(OperatorPlan entity)
    {
        await _context.OperatorPlans.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OperatorPlan>> GetByOperatorIdAsync(Guid operatorId)
    {
        var list = await _context.OperatorPlans
                   .Include(op => op.Plan)
                     .Include(op => op.Operator)
                     .Include(op => op.Plan.Internet)
                   .Where(op => op.OperatorId == operatorId)
                   .ToListAsync();
        
        if (list.Count == 0) throw new NotFoundException("Não foi encontrado nenhum plano para essa operadora.");
        return list;
    }
}