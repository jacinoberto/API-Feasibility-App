using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyOperatorRepository
{   
    Task CreateAsync(CompanyOperator entity);
    Task<IEnumerable<CompanyOperator>> GetAllByCompanyIdAsync(Guid companyId);
    Task<bool> CheckByCompanyIdAsync(Guid companyId, Guid operatorId);
}