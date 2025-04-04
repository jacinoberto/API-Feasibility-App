using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlanObservationRepositoryImpl(AppDbContext context) : IPlanObservationRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<PlanObservation> CreateAsync(PlanObservation entity)
    {
        await _context.PlanObservations.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<PlanObservation>> GetByPlanIdAsync(Guid planId)
    {
        return await _context.PlanObservations
            .Include(po => po.Observation)
            .Where(po => po.PlanId == planId && po.IsActive == true)
            .ToListAsync();
    }
}