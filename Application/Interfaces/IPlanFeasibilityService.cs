using Application.DTOs;

namespace Application.Interfaces;

public interface IPlanFeasibilityService
{
    Task CreateAsync(CreatePlanFeasibilityDto dto);
    Task CreateAllAsync(IEnumerable<CreatePlanFeasibilityDto> listDto);
    Task<ReturnPlanFeasibilitDto> GetByParametersAsync(string? zipCode, string? city, string? state);
}