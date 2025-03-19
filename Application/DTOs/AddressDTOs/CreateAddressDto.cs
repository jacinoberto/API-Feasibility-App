using System.ComponentModel.DataAnnotations;
using Domain.Utils.Validations;

namespace Application.DTOs.AddressDTOs;

public record CreateAddressDto(
    Guid StateId,
    string ZipCode,
    string Street,
    int Number,
    string Area,
    string City
    );