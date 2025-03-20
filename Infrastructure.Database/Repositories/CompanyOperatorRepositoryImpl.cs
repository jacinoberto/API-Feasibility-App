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

    public async Task<CompanyOperator> GetByCompanyIdAsync(Guid companyId)
    {
        return await _context.CompanyOperators
                   .Include(c => c.Operator)
                   .Include(c => c.Company)
                   .FirstOrDefaultAsync(c => c.CompanyId == companyId)
               ?? throw new NotFoundException("Não foi encontrada nenhuma operadora vinculada a essa empresa.");
    }
}