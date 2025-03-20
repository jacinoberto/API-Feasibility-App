namespace Application.DTOs.AddressDTOs;

public record ReturnAddressDto(
    Guid Id,
    string? ZipCode,
    string? Street,
    int? Number,
    string? Area,
    string? City,
    string? State
    );