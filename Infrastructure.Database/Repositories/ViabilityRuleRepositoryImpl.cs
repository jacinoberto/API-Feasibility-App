using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ViabilityRuleRepositoryImpl(AppDbContext context) : IViabilityRuleRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<ViabilityRule> CreateAsync(ViabilityRule entity)
    {
        var viabilityRules = await _context.ViabilityRules.Where(
            vr => vr.CompanyId == entity.CompanyId && vr.FeasibilityTypeId != entity.FeasibilityTypeId && vr.IsActive == true)
            .ToListAsync();

        if (viabilityRules.Count > 0) throw new InternalErrorException("Sua empresa já tem uma regra estabelecida pra a consulta dos planos, inative essa configuração para poder adicionar outra.");
        
        await _context.ViabilityRules.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<IEnumerable<ViabilityRule>> GetByCityAndState(string city, string state, Guid companyId)
    {
        var viabilityrules = await _context.ViabilityRules
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
        
        if (viabilityrules.Count == 0) throw new NotFoundException("Sua empresa não possuí planos registrados no sistema para essa região.");

        return viabilityrules;
    }

    public async Task<IEnumerable<ViabilityRule>> GetByZipCode(string zipCode, Guid companyId)
    {
        var viabilityrules = await _context.ViabilityRules
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
        
        if (viabilityrules.Count == 0) throw new NotFoundException("Sua empresa não possuí planos registrados no sistema para essa região.");

        return viabilityrules;
    }
    
    public async Task<ICollection<ViabilityRule>> GetByCity(string city, Guid companyId)
    {
        var viabilityrules = await _context.ViabilityRules
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

        if (viabilityrules.Count == 0) throw new NotFoundException("Sua empresa não possuí planos registrados no sistema para essa região.");

        return viabilityrules;
    }
    
    public async Task DisableAsync(Guid companyId)
    {
        var viabilityRules = await _context.ViabilityRules.Where(vr =>
                vr.CompanyId == companyId
                && vr.IsActive == true)
            .ToListAsync();

        var plansId = viabilityRules.Select(vr => vr.PlanId).ToList();

        if (viabilityRules.Count == 0) throw new NotFoundException("A sua empresa não possuí nenhuma configuração para a consulta dos planos!");
        
        foreach (var viabilityRule in viabilityRules)
        {
            foreach (var planId in plansId)
            {
                var plan = await _context.Plans.FindAsync(planId);
                plan.DeactivatePlan();
                await _context.SaveChangesAsync();
            }
            
            var viabilityState = await _context.ViabilityStates.Where(vs => vs.ViabilityRuleId == viabilityRule.Id).FirstOrDefaultAsync();
            var viabilityCity = await _context.ViabilityCities.Where(vc => vc.ViabilityRuleId == viabilityRule.Id).FirstOrDefaultAsync();

            if (viabilityState is not null)
            {
                viabilityState.Disable();
                await _context.SaveChangesAsync();
            }
            
            if (viabilityCity is not null)
            {
                viabilityCity.Disable();
                await _context.SaveChangesAsync();
            }
            
            viabilityRule.Disable();
            await _context.SaveChangesAsync();
        }
    }
}