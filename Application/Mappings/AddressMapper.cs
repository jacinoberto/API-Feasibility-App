using Application.DTOs.AddressDTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class AddressMapper
{
    public static Address MapToAddress(CreateAddressDto dto)
    {
        return AddressFactory.Create(dto.StateId, dto.ZipCode, dto.Street, dto.Number, dto.Area, dto.City);
    }

    public static ReturnAddressDto MapToReturnAddressDto(Address address)
    {
        return new ReturnAddressDto(address.Id, address.ZipCode, address.Street, address.Number, address.Area,
            address.City, address.State?.Uf);
    }
}