using Application.DTOs.PlanDTOs;
using Application.DTOs.ViabilityRuleDTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPlanService
{
    Task CreatePlan(CreatePlanDto dto);
    Task<ReturnPlanDto> GetPlanByIdAsync(Guid id);
    Task<IEnumerable<ReturnPlanDto>> GetAllPlansAsync();

    Task CreatePlanByStateAsync(CreateViabilityRuleByStateDto dto);
    Task CreatePlanByCityAsync(CreateViabilityRuleByCityDto dto);
    Task CreateAllPlanByStateAsync(IEnumerable<CreateViabilityRuleByStateDto> dtos);
    Task CreateAllPlanByCityAsync(IEnumerable<CreateViabilityRuleByCityDto> dtos);
}