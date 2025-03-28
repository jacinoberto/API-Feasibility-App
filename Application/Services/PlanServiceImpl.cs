using Application.CQRS.AddressCQRS.Queries;
using Application.CQRS.FeasibilityTypeCQRS.Queries;
using Application.CQRS.InternetCQRS.Commands;
using Application.CQRS.InternetCQRS.Queries;
using Application.CQRS.PlanCQRS.Commands;
using Application.CQRS.PlanCQRS.Queries;
using Application.CQRS.StateCQRS.Queries;
using Application.CQRS.ViabilityCityCQRS.Commands;
using Application.CQRS.ViabilityRuleCQRS.Commands;
using Application.CQRS.ViabilityStateCQRS;
using Application.DTOs.PlanDTOs;
using Application.DTOs.ViabilityRuleDTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Exceptions;
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

    public async Task CreatePlanByStateAsync(CreateViabilityRuleByStateDto dto)
    {
        var internet = await _mediator.Send(new ReturnInternetByInternetSpeedQuery(dto.InternetSpeed));
        if (internet is null)
            internet = await _mediator.Send(new CreateInternetCommand(dto.InternetSpeed, dto.SpeedType));

        var plan = await _mediator.Send(new ReturnPlanByParametersQuery(dto.Plan, dto.Value, internet.Id));
        if (plan is null)
            plan = await _mediator.Send(new CreatePlanCommand(internet.Id, dto.Plan, dto.Value));
        
        var state = await _mediator.Send(new ReturnStateByUfQuery(dto.State));

        if (!await CheckFeasibilityTypeIsState(dto.FeasibilityTypeId))
            throw new InternalErrorException("Sua empresa já tem uma regra estabelecida pra a consulta dos valores dos planos serem realizadas por estado, inative essa configuração para poder adicionar outra.");
            
        var viabilityRule = await _mediator.Send(new CreateViabilityRuleCommand(plan.Id, dto.CompanyId, dto.FeasibilityTypeId));
        await _mediator.Send(new CreateViabilityStateCommand(viabilityRule.Id, state.Id));
    }
    
    public async Task CreatePlanByCityAsync(CreateViabilityRuleByCityDto dto)
    {
        var internet = await _mediator.Send(new ReturnInternetByInternetSpeedQuery(dto.InternetSpeed));
        if (internet is null)
            internet = await _mediator.Send(new CreateInternetCommand(dto.InternetSpeed, dto.SpeedType));

        var plan = await _mediator.Send(new ReturnPlanByParametersQuery(dto.Plan, dto.Value, internet.Id));
        if (plan is null)
            plan = await _mediator.Send(new CreatePlanCommand(internet.Id, dto.Plan, dto.Value));

        if (await CheckFeasibilityTypeIsState(dto.FeasibilityTypeId))
            throw new InternalErrorException("Sua empresa já tem uma regra estabelecida pra a consulta dos valores dos planos serem realizadas por cidade, inative essa configuração para poder adicionar outra.");
        
        var address = await _mediator.Send(new ReturnAddressByCityAndStateQuery(dto.City, dto.State));
        
        var viabilityRule = await _mediator.Send(new CreateViabilityRuleCommand(plan.Id, dto.CompanyId, dto.FeasibilityTypeId));
        await _mediator.Send(new CreateViabilityCityCommand(viabilityRule.Id, address.Id));
    }

    public async Task CreateAllPlanByStateAsync(IEnumerable<CreateViabilityRuleByStateDto> dtos)
    {
        foreach (var dto in dtos)
        {
            await CreatePlanByStateAsync(dto);
        }
    }

    public async Task CreateAllPlanByCityAsync(IEnumerable<CreateViabilityRuleByCityDto> dtos)
    {
        foreach (var dto in dtos)
        {
            await CreatePlanByCityAsync(dto);
        }
    }
  
    private async Task<bool> CheckFeasibilityTypeIsState(Guid feasibilityId)
    {
        var state = await _mediator.Send(new ReturnFeasibilityTypeByIdQuery(feasibilityId));
        return state.Type == "Estado";
    }
    
    public async Task DisablePlansAsync(Guid companyId)
    {
        await _mediator.Send(new DisableViabilityByCompanyIdCommand(companyId));
    }
}