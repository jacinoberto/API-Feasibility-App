using Application.DTOs.InternetDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class InternetMapper
{
    public static Internet MapToInternet(CreateInternetDto dto)
    {
        return new Internet(dto.InternetSpeed, dto.SpedType);
    }

    public static ReturnInternetDto MapToReturnInternetDto(Internet internet)
    {
        return new ReturnInternetDto(internet.Id, internet.InternetSpeed, internet.SpeedType);
    }
}