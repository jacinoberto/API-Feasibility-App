using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class CompanyRepositoryImpl(AppDbContext context) : ICompanyRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task CreateAsync(Company entity)
    {
        await _context.Companies.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Company> GetByIdAsync(Guid id)
    {
        return await _context.Companies.FindAsync(id)
            ?? throw new NotFoundException("Não foi encontrada nenhuma empresa com o ID informado.");
    }

    public async Task UpdateAsync(Guid id, Company entity)
    {
        var company = await GetByIdAsync(id);
        
        company.ChangeCompany(entity.CompanyName, entity.ResponsibleContact, entity.FinancialContact, entity.ResponsibleEmail,
            entity.FinancialEmail);
    }

    public async Task DeleteAsync(Guid id)
    {
        var company = await GetByIdAsync(id);
        company.DeactivateCompany();
        await _context.SaveChangesAsync();
    }
}