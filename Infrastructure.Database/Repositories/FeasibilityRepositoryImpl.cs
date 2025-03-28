using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FeasibilityRepositoryImpl(AppDbContext context) : IFeasibilityRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Feasibility> CreateAsync(Feasibility entity)
    {
        await _context.Feasibilities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<bool> CheckByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId)
    {
        var feasibility = await _context.Feasibilities
            .Where(f =>
                _context.CompanyOperators
                    .Where(cp => cp.CompanyId == companyId)
                    .Select(cp => cp.OperatorId)
                    .Any(id => id == operatorId)
                
                && _context.RegionConsultations
                    .Where(rc => rc.CompanyId == companyId)
                    .Select(rc => rc.StateId)
                    .Any(id => id == f.Address.StateId)
                
                && f.Address.City.ToUpper().Contains(city.ToUpper())
                && f.Address.State.Uf.ToUpper().Contains(state.ToUpper()))
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Não há viabilidade para essa cidade e estado.");
        
        return true;
    }
    
    public async Task<bool> CheckByZipCodeAsync(string zipCode, Guid companyId, Guid operatorId)
    {
        var feasibility = await _context.Feasibilities
            .Where(f =>
                _context.CompanyOperators
                    .Where(cp => cp.CompanyId == companyId)
                    .Select(cp => cp.OperatorId)
                    .Any(id => id == operatorId)
                
                && _context.RegionConsultations
                    .Where(rc => rc.CompanyId == companyId)
                    .Select(rc => rc.StateId)
                    .Any(id => id == f.Address.StateId)
                
                && f.Address.ZipCode.Contains(zipCode))
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Não há viabilidade para essa cidade e estado.");
        
        return true;
    }
    
    public async Task<bool> CheckByCityAsync(string city, Guid companyId, Guid operatorId)
    {
        var feasibility = await _context.Feasibilities
            .Where(f =>
                _context.CompanyOperators
                    .Where(cp => cp.CompanyId == companyId)
                    .Select(cp => cp.OperatorId)
                    .Any(id => id == operatorId)
                
                && _context.RegionConsultations
                    .Where(rc => rc.CompanyId == companyId)
                    .Select(rc => rc.StateId)
                    .Any(id => id == f.Address.StateId)
                
                && f.Address.City.ToUpper().Contains(city.ToUpper()))
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Não há viabilidade para essa cidade e estado.");
        
        return true;
    }
}