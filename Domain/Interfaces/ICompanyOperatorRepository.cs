using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyOperatorRepository
{   
    Task CreateAsync(CompanyOperator entity);
    Task<IEnumerable<CompanyOperator>> GetByCompanyIdAsync(Guid companyId);
}