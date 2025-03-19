using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class AddressRepositoryImpl(AppDbContext context) : IAddressRepository
{
    private readonly AppDbContext _context = context;

    public async Task CreateAsync(State entity)
    {
        await _context.States.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Address> GetByIdAsync(Guid id)
    {
        return await _context.Addresses.FindAsync(id)
            ?? throw new NotFoundException("Não foi entrado nenhum endereço com o ID informado.");
    }
}