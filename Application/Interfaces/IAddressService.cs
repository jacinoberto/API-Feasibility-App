using Application.DTOs.AddressDTOs;

namespace Application.Interfaces;

public interface IAddressService
{
    Task CreateAddressAsync(CreateAddressDto dto);
    Task<ReturnAddressDto> GetAddressByIdAsync(Guid id);
}