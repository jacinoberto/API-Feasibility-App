using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.AddressCQRS.Queries;
using Application.CQRS.InternetCQRS.Commands;
using Application.CQRS.InternetCQRS.Queries;
using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.CQRS.OperatorPlanCQRS.Commands;
using Application.CQRS.PlanCQRS.Commands;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Services;

public class PlanFeasibilityServiceImpl(IMediator mediator) : IPlanFeasibilityService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreatePlanFeasibilityDto dto)
    {
        // Busca a operadora pelo nome informado
        var operatorExist = await _mediator.Send(new ReturnOperatorByNameQuery(dto.Operator));
        var internetExist = await _mediator.Send(new ReturnInternetByInternetSpeedQuery(dto.InternetSpeed));
        var addressExist = await _mediator.Send(new ReturnAddressByParametersQuery(dto.ZipCode, dto.City, dto.State));


        if (internetExist is null) internetExist = await _mediator.Send(new CreateInternetCommand(dto.InternetSpeed, dto.SpeedType));
        if (addressExist is null) addressExist = await _mediator.Send(new CreateAddressCommand(new Guid(), dto.ZipCode, 
            dto.Street, dto.Number, dto.Area, dto.City));
        
        /*
         * Se uma operadora for retornada ela é vinculada aos planos, caso contrário é realizado o cadastro de uma nova
         * operadora e vinculo entre os planos.
         */
        if (operatorExist is not null)
        {
            var planResult = await _mediator.Send(new CreatePlanCommand(internetExist.Id, dto.PlanName,
                dto.Value));
            
            await _mediator.Send(new CreateOperatorPlanCommand(operatorExist.Id, planResult.Id));
            
        }
        else
        {
            var operatorResult = await _mediator.Send(new CreateOperatorCommand(dto.Operator));
            var planResult = await _mediator.Send(new CreatePlanCommand(internetExist.Id, dto.PlanName,
                dto.Value));
            
            await _mediator.Send(new CreateOperatorPlanCommand(operatorResult.Id, planResult.Id));
        }
        
    }

    public Task CreateAllAsync(IEnumerable<CreatePlanFeasibilityDto> listDto)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnPlanFeasibilitDto> GetByParametersAsync(string? zipCode, string? city, string? state)
    {
        throw new NotImplementedException();
    }
}