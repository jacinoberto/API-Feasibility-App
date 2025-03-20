using Application.CQRS.PlanCQRS.Commands;
using Application.CQRS.PlanCQRS.Queries;
using Application.DTOs.PlanDTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using MediatR;

namespace Application.Services;

public class PlanServiceImpl(IMediator mediator) : IPlanService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreatePlan(CreatePlanDto dto)
    {
        await _mediator.Send(new CreatePlanCommand(dto.InternetId, dto.PlanName, dto.Value));
    }

    public async Task<ReturnPlanDto> GetPlanByIdAsync(Guid id)
    {
        return PlanMapper.MapToReturnPlanDto(
            await _mediator.Send(new ReturnPlanByIdQuery(id)));
    }

    public async Task<IEnumerable<ReturnPlanDto>> GetAllPlansAsync()
    {
        var plans = await _mediator.Send(new ReturnAllPlansQuery());
        
        return plans
            .Select(plan => PlanMapper.MapToReturnPlanDto(plan))
            .ToList();
    }
}