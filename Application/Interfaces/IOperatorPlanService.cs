using Application.DTOs.OperationPlanDTOs;

namespace Application.Interfaces;

public interface IOperatorPlanService
{
    Task CreateAsync(CreateOperatorPlanDto dto);
    Task CreateAllByUploadAsync(IEnumerable<CreateOperatorPlanDto> listDto);
    Task<IEnumerable<ReturnOperatorPlanDto>> GetPlansByOperatorIdAsync(Guid operatorId);
}