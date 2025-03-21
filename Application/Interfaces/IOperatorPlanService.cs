using Application.DTOs.OperationPlanDTOs;

namespace Application.Interfaces;

public interface IOperatorPlanService
{
    Task CreateAsync(CreateOperatorPlanDto dto);
    Task<IEnumerable<ReturnOperatorPlanDto>> GetPlansByOperatorIdAsync(Guid opertatorId);
}