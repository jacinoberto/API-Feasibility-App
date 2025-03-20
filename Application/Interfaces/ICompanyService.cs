using Application.DTOs.CompanyDTOs;

namespace Application.Interfaces;

public interface ICompanyService
{
    Task CreateAsync(CreateCompanyDto dto);
    Task<ReturnCompanyDto> GetByIdAsync(Guid id);
}