using Application.DTOs.StateDTOs;

namespace Application.Interfaces;

public interface IStateService
{
    Task<ReturnStateDto> GetStateByIdAsync(Guid id);
    Task<IEnumerable<ReturnStateDto>> GetStatesAllAsync();
}