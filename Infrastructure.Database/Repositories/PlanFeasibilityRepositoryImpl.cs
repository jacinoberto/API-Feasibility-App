using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlanFeasibilityRepositoryImpl(AppDbContext context) : IPlanFeasibilityRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(PlanFeasibility entity)
    {
        await _context.PlanFeasibilities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<PlanFeasibility> GetByParametersAsync(string? zipCode, string? city, string? state)
    {
        if (zipCode is not null) return await GetByZipCodeAsync(zipCode);
        if (city is not null) return await GetByCityAsync(city);
        if (state is not null) return await GetByStateAsync(state);
        throw new NotFoundException("Não foi entrada nenhuma viabilidade de plano para nenhum dos parâmetros informados.");
    }

    public async Task<IEnumerable<PlanFeasibility>> GetByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId)
    {
        var list = await _context.PlanFeasibilities
            .Include(f => f.OperatorPlan)
            .Include(f => f.OperatorPlan.Operator)
            .Include(f => f.OperatorPlan.Plan)
            .Include(f => f.OperatorPlan.Plan.Internet)
            .Where(pf =>
                _context.CompanyOperators
                    .Where(co => co.CompanyId == companyId)
                    .Select(co => co.OperatorId)
                    .Any(id => id == pf.OperatorPlan.OperatorId) // ✅ Usa Any() no IQueryable

                && _context.RegionConsultations
                    .Where(rc => rc.CompanyId == companyId)
                    .Select(rc => rc.StateId)
                    .Any(id => id == pf.Address.StateId) // ✅ Usa Any() no IQueryable

                && pf.OperatorPlan.OperatorId == operatorId
                && pf.Address.City.ToUpper().Contains(city.ToUpper())
                && pf.Address.State.Uf.ToUpper().Contains(state.ToUpper()))
            .ToListAsync();

        return list.Count > 0 ? list : throw new NotFoundException("Não há viabilidade para a cidade e estado informados.");
    }

    public async Task<PlanFeasibility> GetByZipCodeAsync(Guid companyId, Guid operatorId, string zipCode)
    {
       return await _context.PlanFeasibilities
            .Include(f => f.OperatorPlan)
            .Include(f => f.OperatorPlan.Operator)
            .Include(f => f.OperatorPlan.Plan)
            .Include(f => f.OperatorPlan.Plan.Internet)
            .Where(pf =>
                _context.CompanyOperators
                    .Where(co => co.CompanyId == companyId)
                    .Select(co => co.OperatorId)
                    .Any(id => id == pf.OperatorPlan.OperatorId) // ✅ Usa Any() no IQueryable

                && _context.RegionConsultations
                    .Where(rc => rc.CompanyId == companyId)
                    .Select(rc => rc.StateId)
                    .Any(id => id == pf.Address.StateId) // ✅ Usa Any() no IQueryable

                && pf.OperatorPlan.OperatorId == operatorId
                && pf.Address.ZipCode == zipCode)
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("Não há viabilidade para este CEP.");
    }

    public async Task<PlanFeasibility> GetByCityAsync(Guid companyId, Guid operatorId, string city)
    {
        return await _context.PlanFeasibilities
                   .Include(f => f.OperatorPlan)
                   .Include(f => f.OperatorPlan.Operator)
                   .Include(f => f.OperatorPlan.Plan)
                   .Include(f => f.OperatorPlan.Plan.Internet)
                   .Where(pf =>
                       _context.CompanyOperators
                           .Where(co => co.CompanyId == companyId)
                           .Select(co => co.OperatorId)
                           .Any(id => id == pf.OperatorPlan.OperatorId) // ✅ Usa Any() no IQueryable

                       && _context.RegionConsultations
                           .Where(rc => rc.CompanyId == companyId)
                           .Select(rc => rc.StateId)
                           .Any(id => id == pf.Address.StateId) // ✅ Usa Any() no IQueryable

                       && pf.OperatorPlan.OperatorId == operatorId
                       && pf.Address.City.ToUpper().Contains(city.ToUpper()))
                   .FirstOrDefaultAsync()
               ?? throw new NotFoundException("Não há viabilidade para esta Cidade.");
    }

    public async Task<PlanFeasibility> GetByZipCodeAsync(string zipCode)
    {
        return await _context.PlanFeasibilities
            .Include(f => f.OperatorPlan)
            .Include(f => f.OperatorPlan.Operator)
            .Include(f => f.OperatorPlan.Plan)
            .Include(f => f.OperatorPlan.Plan.Internet)
            .FirstOrDefaultAsync(f => f.Address.ZipCode != null
                                      && f.Address.ZipCode.ToUpper()
                                          .Contains(zipCode.ToUpper()))
            ?? throw new NotFoundException("Não foi encontrada nenhuma viabilidade de plano para esse CEP.");
    }

    public async Task<PlanFeasibility> GetByCityAsync(string city)
    {
        return await _context.PlanFeasibilities
                   .Include(f => f.OperatorPlan)
                   .Include(f => f.OperatorPlan.Operator)
                   .Include(f => f.OperatorPlan.Plan)
                   .Include(f => f.OperatorPlan.Plan.Internet)
                   .FirstOrDefaultAsync(f => f.Address.City != null 
                                             && f.Address.City.ToUpper()
                                                 .Contains(city
                                                     .ToUpper()))
               ?? throw new NotFoundException("Não foi encontrada nenhuma viabilidade de plano para essa cidade.");
    }

    public async Task<PlanFeasibility> GetByStateAsync(string state)
    {
        return await _context.PlanFeasibilities
                   .Include(f => f.OperatorPlan)
                   .Include(f => f.OperatorPlan.Operator)
                   .Include(f => f.OperatorPlan.Plan)
                   .Include(f => f.OperatorPlan.Plan.Internet)
                   .FirstOrDefaultAsync(f => f.Address.State != null 
                                             && f.Address.State.Uf.ToUpper()
                                                 .Contains(state.ToUpper()))
               ?? throw new NotFoundException("Não foi encontrada nenhuma viabilidade de plano para esse estado.");
    }
}