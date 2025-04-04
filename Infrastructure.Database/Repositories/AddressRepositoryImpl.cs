﻿using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AddressRepositoryImpl(AppDbContext context) : IAddressRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Address> CreateAsync(Address entity)
    {
        await _context.Addresses.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Address> GetByIdAsync(Guid id)
    {
        return await _context.Addresses
                   .Include(a => a.State)
                   .SingleOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException("Não foi entrado nenhum endereço com o ID informado.");
    }

    public async Task<Address> GetByCityAndStateAsync(string city, string state)
    {
        return await _context.Addresses
            .FirstOrDefaultAsync(a => a.City == city && a.State.Uf == state)
            ?? throw new NotFoundException("Não há viabilidade para esta cidade na base dados da operadora!");
    }

    public async Task<Address> GetByParameters(string? zipCode, string? city, string? state)
    {
        return await _context.Addresses
            .Include(a => a.State)
            .FirstOrDefaultAsync(a => a.ZipCode.Contains(zipCode)
            || a.City.ToUpper().Contains(city.ToUpper())
            || a.State.Uf.ToUpper().Contains(state.ToUpper()));
    }

    public async Task<IEnumerable<Address>> GetByStateAsync(string state)
    {
        return await _context.Addresses
            .Where(a => a.State.Uf == state)
            .ToListAsync();
    }
}