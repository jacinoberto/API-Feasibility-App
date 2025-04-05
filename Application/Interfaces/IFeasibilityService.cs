using Application.DTOs.FeasibilityDTO;

namespace Application.Services;

public interface IFeasibilityService
{
    Task CreateAsync(CreateFeasibilityDto dto);
    Task CreateAllAsync(IEnumerable<CreateFeasibilityDto> dto);
    Task<IEnumerable<ReturnFeasibilityDto>> GetByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId);
    Task<IEnumerable<ReturnFeasibilityDto>> GetByZipCodeAsync(string zipCode, Guid companyId, Guid operatorId);
    Task<ICollection<ReturnFeasibilityDto>> GetByCityAsync(string city, Guid companyId, Guid operatorId);

    Task<IEnumerable<ReturnFeasibilityDto>> GetByAddressAsync(string street, string area, string city, Guid companyId,
        Guid operatorId);
}