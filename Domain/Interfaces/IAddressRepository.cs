using Domain.Entities;

namespace Domain.Interfaces;

public interface IAddressRepository
{
    Task CreateAsync(State entity);
    Task<Address> GetByIdAsync(Guid id);
}