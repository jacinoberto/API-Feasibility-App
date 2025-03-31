using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.AddressCQRS.Queries;
using Application.DTOs.AddressDTOs;
using Application.Interfaces;
using Application.Mappings;
using Application.Utils.Formatting;
using MediatR;

namespace Application.Services;

public class AddressServiceImpl(IMediator mediator, ITextFormattingUtil formatting) : IAddressService
{
    private readonly IMediator _mediator = mediator;
    private readonly ITextFormattingUtil _formatting = formatting;
    
    public async Task CreateAddressAsync(CreateAddressDto dto)
    {
        await _mediator.Send(new CreateAddressCommand(dto.StateId, dto.ZipCode, _formatting.Format(dto.Street),
            dto.Number, _formatting.Format(dto.Area), _formatting.Format(dto.City)));
    }

    public async Task<ReturnAddressDto> GetAddressByIdAsync(Guid id)
    {
        return AddressMapper.MapToReturnAddressDto(
            await _mediator.Send(new ReturnAddressByIdQuery(id)));
    }

    public async Task<IEnumerable<ReturnCitiesDto>> GetCitiesAsync(string state)
    {
        var cities = await _mediator.Send(new ReturnAddressesByStateQuery(state));
        
        return cities.Select(c => AddressMapper.MapToReturnCitiesDto(c)).ToList();
    }
}