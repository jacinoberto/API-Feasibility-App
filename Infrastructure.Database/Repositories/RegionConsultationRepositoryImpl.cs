using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfiguration;

public class RegionConsultationRepositoryImpl(AppDbContext context) : IRegionConsultationRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<RegionConsultation> CreateAsync(RegionConsultation entity)
    {
        await _context.RegionConsultations.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<RegionConsultation>> GetByCompanyIdAsync(Guid companyId)
    {
        var list = await _context.RegionConsultations
                .Include(rc => rc.State)
                .Where(r => r.CompanyId == companyId)
                .ToListAsync();

        return list.Count > 0 ? list : throw new NotFoundException("Não foi criada nenhuma regra de consulta para a sua empresa.");
    }
}