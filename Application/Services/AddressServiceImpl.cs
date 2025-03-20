using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.AddressCQRS.Queries;
using Application.DTOs.AddressDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class AddressServiceImpl(IMediator mediator) : IAddressService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAddressAsync(CreateAddressDto dto)
    {
        await _mediator.Send(new CreateAddressCommand(dto.StateId, dto.ZipCode, dto.Street, dto.Number, dto.Area,
            dto.City));
    }

    public async Task<ReturnAddressDto> GetAddressByIdAsync(Guid id)
    {
        return AddressMapper.MapToReturnAddressDto(
            await _mediator.Send(new ReturnAddressByIdQuery(id)));
    }
}