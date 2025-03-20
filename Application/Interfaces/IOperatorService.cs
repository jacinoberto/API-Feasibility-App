using Application.CQRS.OperatorCQRS;
using Application.DTOs.OperatorDTOs;
namespace Application.Interfaces;

public interface IOperatorService
{
    Task CreateOperatorAsync(CreateOperatorDto dto);
    Task<ReturnOperatorDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ReturnOperatorDto>> GetAllAsync();
}