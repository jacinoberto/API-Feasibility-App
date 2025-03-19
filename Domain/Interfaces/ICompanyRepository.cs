using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyRepository
{
    Task CreateAsync(Company entity);
    Task<Company> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, Company entity);
    Task DeleteAsync(Guid id);
}