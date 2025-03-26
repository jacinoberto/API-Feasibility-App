using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.InternetCQRS.Commands;
using Application.CQRS.InternetCQRS.Queries;
using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.CQRS.OperatorPlanCQRS.Commands;
using Application.CQRS.PlanCQRS.Commands;
using Application.CQRS.PlanFeasibilityCQRS.Commands;
using Application.CQRS.PlanFeasibilityCQRS.Queries;
using Application.CQRS.StateCQRS.Queries;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Application.Utils.Formatting;
using Domain.Entities;
using MediatR;

namespace Application.Services;

public class PlanFeasibilityServiceImpl(IMediator mediator, ITextFormattingUtil formatting) : IPlanFeasibilityService
{
    private readonly IMediator _mediator = mediator;
    private readonly ITextFormattingUtil _formatting = formatting;
    
    /*public async Task CreateAsync(CreatePlanFeasibilityDto dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto), "Os dados do plano são obrigatórios.");

        // Faz uma consulta para verificar se a operadora já existe.
        var operatorExist = await _mediator.Send(new ReturnOperatorByNameQuery(dto.Operator));
        
        // Verifica se já existe uma internet com a velocidade informada, caso não exista, cria uma nova.
        var internetExist = await _mediator.Send(new ReturnInternetByInternetSpeedQuery(dto.InternetSpeed)) 
                            ?? await _mediator.Send(new CreateInternetCommand(dto.InternetSpeed, dto.SpeedType));

        // Se o estado for informado, verifica se o estado existe.
        var stateExist = await _mediator.Send(new ReturnStateByUfQuery(dto.State));

        // Se a operadora não existir, cria uma nova.
        var operatorId = operatorExist?.Id ?? (await _mediator.Send(new CreateOperatorCommand(dto.Operator))).Id;

        // Cria as associações entre as entidades, e cadastra a viabilidade.
        await CrateAssociationAsync(operatorId, internetExist.Id, stateExist?.Id, dto);
    }

    public async Task CreateAllAsync(IEnumerable<CreatePlanFeasibilityDto> listDto)
    {
        foreach (var dto in listDto)
        {
            await CreateAsync(dto);
        }
    }

    public async Task<ReturnPlanFeasibilitDto> GetByZipCodeAsync(Guid companyId, Guid operatorId, string zipCode)
    {
        return PlanFeasibilityMapper.MapToReturnPlanFeasibilityDto(
            await _mediator.Send(new ReturnPlanFeasibilityByZipCodeQuery(companyId, operatorId, zipCode)));
    }

    public async Task<ReturnPlanFeasibilitDto> GetByCityAsync(Guid companyId, Guid operatorId, string city)
    {
        return PlanFeasibilityMapper.MapToReturnPlanFeasibilityDto(
            await _mediator.Send(new ReturnPlanFeasibilityByCityQuery(companyId, operatorId, city)));
    }

    public async Task<IEnumerable<ReturnPlanFeasibilitDto>> GetByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId)
    {
        var list = await _mediator.Send(new ReturnPlanFeasibilityByCityAndStateQuery(_formatting.Format(city), state, companyId, operatorId));
        return list.Select(pf => PlanFeasibilityMapper.MapToReturnPlanFeasibilityDto(pf)).ToList();
    }

    public async Task<ReturnPlanFeasibilitDto> GetByParametersAsync(string? zipCode, string? city, string? state)
    {
        return PlanFeasibilityMapper.MapToReturnPlanFeasibilityDto(
            await _mediator.Send(new ReturnPlanFeasibilityByParametersQuery(zipCode, _formatting.Format(city), state)));
    }

    private async Task CrateAssociationAsync(Guid operatorId, Guid internetId, Guid? stateId,
        CreatePlanFeasibilityDto dto)
    {
        var planResult = await _mediator.Send(new CreatePlanCommand(internetId, null, Decimal.Zero));
        var op = await _mediator.Send(new CreateOperatorPlanCommand(operatorId, planResult.Id));
        var ad = await _mediator.Send(new CreateAddressCommand(stateId, dto.ZipCode, _formatting.Format(dto.Street),
            dto.Number, _formatting.Format(dto.Area), _formatting.Format(dto.City)));

        await _mediator.Send(new CreatePlanFeasibilityCommand(op.Id, ad.Id));
    }*/
}