using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyRepository
{
    Task<Company> CreateAsync(Company entity);
    Task<Company> GetByIdAsync(Guid id);
    Task<Company> UpdateAsync(Guid id, Company entity);
    Task DeleteAsync(Guid id);
}