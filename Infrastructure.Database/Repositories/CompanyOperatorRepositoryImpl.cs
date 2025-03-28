using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CompanyOperatorRepositoryImpl(AppDbContext context) : ICompanyOperatorRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(CompanyOperator entity)
    {
        await _context.CompanyOperators.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CompanyOperator>> GetAllByCompanyIdAsync(Guid companyId)
    {
        return await _context.CompanyOperators
                   .Include(c => c.Operator)
                   .Include(c => c.Company)
                   .Where(c => c.CompanyId == companyId)
                   .ToListAsync()
               ?? throw new NotFoundException("Não foi encontrada nenhuma operadora vinculada a essa empresa.");
    }

    public async Task<bool> CheckByCompanyIdAsync(Guid companyId, Guid operatorId)
    {
        return await _context.CompanyOperators
            .Where(cp => cp.CompanyId == companyId)
            .Select(cp => cp.OperatorId)
            .AnyAsync(id => id == operatorId);
    }
}