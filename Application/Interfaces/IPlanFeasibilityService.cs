using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPlanFeasibilityService
{
    Task CreateAsync(CreatePlanFeasibilityDto dto);
    Task CreateAllAsync(IEnumerable<CreatePlanFeasibilityDto> listDto);
    Task<ReturnPlanFeasibilitDto> GetByZipCodeAsync(Guid companyId, string zipCode);
    Task<ReturnPlanFeasibilitDto> GetByCityAsync(Guid companyId, string city);
    Task<IEnumerable<ReturnPlanFeasibilitDto>> GetByCityAndStateAsync(string city, string state, Guid companyId);
    Task<ReturnPlanFeasibilitDto> GetByParametersAsync(string? zipCode, string? city, string? state);
}