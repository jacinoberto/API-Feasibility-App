using Application.DTOs.CompanyOperatorDTOs;

namespace Application.Interfaces;

public interface ICompanyOperatorService
{
    Task CreateAsync(CreateCompanyOperatorDto dto);
    Task<IEnumerable<ReturnCompanyOperatorDto>> GetByCompanyIdAsync(Guid companyId);
}