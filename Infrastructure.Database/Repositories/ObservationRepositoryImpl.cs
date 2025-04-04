using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ObservationRepositoryImpl(AppDbContext context) : IObservationRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Observation> CreateAsync(Observation entity)
    {
        await _context.Observations.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}