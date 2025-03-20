using Application.DTOs.StateDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class StateMapper
{
    public static ReturnStateDto MapToReturnStateDto(State state)
    {
        return new ReturnStateDto(state.Id, state.Uf);
    }
}