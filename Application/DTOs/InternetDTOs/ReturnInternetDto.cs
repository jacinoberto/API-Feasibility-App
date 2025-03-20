namespace Application.DTOs.InternetDTOs;

public record ReturnInternetDto(
    Guid Id,
    int InternetSpeed,
    string SpeedType
    );