using Domain.Entities;

namespace Domain.Interfaces;

public interface IAddressRepository
{
    Task<Address> CreateAsync(Address entity);
    Task<Address> GetByIdAsync(Guid id);
    Task<Address> GetByParameters(string? zipCode, string? city, string? state);
}