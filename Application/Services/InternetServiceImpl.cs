using Application.CQRS.InternetCQRS.Commands;
using Application.CQRS.InternetCQRS.Queries;
using Application.DTOs.InternetDTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using MediatR;

namespace Application.Services;

public class InternetServiceImpl(IMediator mediator) : IInternetService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateInternetDto dto)
    {
        await _mediator.Send(new CreateInternetCommand(dto.InternetSpeed, dto.SpedType));
    }

    public async Task<ReturnInternetDto> GetByIdAsync(Guid id)
    {
        return InternetMapper.MapToReturnInternetDto(
            await _mediator.Send(new ReturnInternetByIdQuery(id)));
    }

    public async Task<IEnumerable<ReturnInternetDto>> GetAllAsync()
    {
        var internets = await _mediator.Send(new ReturnAllInternetsQuery());

        return internets
            .Select(internet => InternetMapper.MapToReturnInternetDto(internet))
            .ToList();
    }
}