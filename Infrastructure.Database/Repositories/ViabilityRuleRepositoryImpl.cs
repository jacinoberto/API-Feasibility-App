using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ViabilityRuleRepositoryImpl(AppDbContext context) : IViabilityRuleRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<ViabilityRule> CreateAsync(ViabilityRule entity)
    {
        await _context.ViabilityRules.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<IEnumerable<ViabilityRule>> GetByCityAndState(string city, string state, Guid companyId)
    {
        return await _context.ViabilityRules
            .Include(vr => vr.Plan)
            .Include(vr => vr.Plan.Internet)
            .Include(vr => vr.FeasibilityType)
            .Where(vr => vr.FeasibilityType.Type == "Estado"
                         && vr.CompanyId == companyId
                         && vr.ViabilityStates.Any(vs => vs.State.Uf.ToUpper() == state.ToUpper())
                         && vr.IsActive == true
                         
                         || vr.FeasibilityType.Type == "Cidade"
                         && vr.CompanyId == companyId
                         && vr.ViabilityCities.Any(vc => vc.Address.City.ToUpper().Contains(city.ToUpper()) && vc.Address.State.Uf.ToUpper() == state.ToUpper())
                         && vr.IsActive == true)
            .ToListAsync();
    }

    public async Task<IEnumerable<ViabilityRule>> GetByZipCode(string zipCode, Guid companyId)
    {
        return await _context.ViabilityRules
            .Include(vr => vr.Plan)
            .Include(vr => vr.Plan.Internet)
            .Include(vr => vr.FeasibilityType)
            .Where(vr => vr.FeasibilityType.Type == "Estado"
                         && vr.CompanyId == companyId
                         && vr.ViabilityStates.Any(vs => vs.State.Addresses.Any(a => a.ZipCode.Contains(zipCode)))
                         && vr.IsActive == true
                         
                         || vr.FeasibilityType.Type == "Cidade"
                         && vr.CompanyId == companyId
                         && vr.ViabilityCities.Any(vc => vc.Address.ZipCode.Contains(zipCode))
                         && vr.IsActive == true)
            .ToListAsync();
    }
    
    public async Task<ICollection<ViabilityRule>> GetByCity(string city, Guid companyId)
    {
        return await _context.ViabilityRules
            .Include(vr => vr.Plan)
            .Include(vr => vr.Plan.Internet)
            .Include(vr => vr.FeasibilityType)
            .Where(vr => vr.FeasibilityType.Type == "Estado"
                         && vr.CompanyId == companyId
                         && vr.ViabilityStates.Any(vs => vs.State.Addresses.Any(a => a.City.ToUpper().Contains(city.ToUpper())))
                         && vr.IsActive == true
                         
                         || vr.FeasibilityType.Type == "Cidade"
                         && vr.CompanyId == companyId
                         && vr.ViabilityCities.Any(vc => vc.Address.City.ToUpper().Contains(city.ToUpper()))
                         && vr.IsActive == true)
            .ToListAsync();
    }
}