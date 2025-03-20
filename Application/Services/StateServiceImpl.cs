using Application.CQRS.StateCQRS.Queries;
using Application.DTOs.StateDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class StateServiceImpl(IMediator mediator) : IStateService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task<ReturnStateDto> GetStateByIdAsync(Guid id)
    {
        return StateMapper.MapToReturnStateDto(await _mediator.Send(new ReturnStateByIdQuery(id)));
    }

    public async Task<IEnumerable<ReturnStateDto>> GetStatesAllAsync()
    {
        var states = await _mediator.Send(new ReturnAllStatesQuery());
        return states.Select(s => new ReturnStateDto(s.Id, s.Uf)).ToList();
    }
}