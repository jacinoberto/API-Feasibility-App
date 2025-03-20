using Application.DTOs.InternetDTOs;

namespace Application.Interfaces;

public interface IInternetService
{
    Task CreateAsync(CreateInternetDto dto);
    Task<ReturnInternetDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ReturnInternetDto>> GetAllAsync();
}