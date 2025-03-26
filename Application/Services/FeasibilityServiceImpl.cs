using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.AddressCQRS.Queries;
using Application.CQRS.FeasibilityCQRS.Commands;
using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.CQRS.StateCQRS.Queries;
using Application.DTOs.FeasibilityDTO;
using MediatR;

namespace Application.Services;

public class FeasibilityServiceImpl(IMediator mediator) : IFeasibilityService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateFeasibilityDto dto)
    {
        var operatorExist = await _mediator.Send(new ReturnOperatorByNameQuery(dto.Operator));
        var state = await _mediator.Send(new ReturnStateByUfQuery(dto.State));
        var address = await _mediator.Send(new ReturnAddressByParametersQuery(dto.ZipCode, dto.City, dto.State));

        if (operatorExist is null) operatorExist = await _mediator.Send(new CreateOperatorCommand(dto.Operator));
        if (address is null) address = await _mediator.Send(new CreateAddressCommand(state.Id, dto.ZipCode, dto.Street,
            dto.Number, dto.Area, dto.City));

        Console.WriteLine(operatorExist.Id + "," + address.Id);
        var teste = new CreateFeasibilityCommand(operatorExist.Id, address.Id);
        Console.WriteLine(teste.OperatorId + "," + teste.AddressId);
        
        await _mediator.Send(teste);
    }

    public async Task CreateAllAsync(IEnumerable<CreateFeasibilityDto> dtos)
    {
        foreach (var dto in dtos)
        {
            await CreateAsync(dto);
        }
    }
}