using Application.CQRS.AddressCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.AddressCQRS.Handles;

public class CreateAddressCommandHandle(IAddressRepository repository) : IRequestHandler<CreateAddressCommand, Address>
{
    private readonly IAddressRepository _repository = repository;
    
    public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Address(request.StateId, request.ZipCode, request.Street, request.Number,
            request.Area, request.City));
    }
}