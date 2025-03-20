using Application.DTOs.PlanDTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPlanService
{
    Task CreatePlan(CreatePlanDto dto);
    Task<ReturnPlanDto> GetPlanByIdAsync(Guid id);
    Task<IEnumerable<ReturnPlanDto>> GetAllPlansAsync();
}