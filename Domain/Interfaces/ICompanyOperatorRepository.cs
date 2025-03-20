using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyOperatorRepository
{   
    Task CreateAsync(CompanyOperator entity);
    Task<CompanyOperator> GetByCompanyIdAsync(Guid companyId);
}