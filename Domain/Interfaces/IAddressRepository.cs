using Domain.Entities;

namespace Domain.Interfaces;

public interface IAddressRepository
{
    Task<Address> CreateAsync(Address entity);
    Task<Address> GetByIdAsync(Guid id);
}