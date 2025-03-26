using Application.DTOs.FeasibilityDTO;

namespace Application.Services;

public interface IFeasibilityService
{
    Task CreateAsync(CreateFeasibilityDto dto);
    Task CreateAllAsync(IEnumerable<CreateFeasibilityDto> dto);
}