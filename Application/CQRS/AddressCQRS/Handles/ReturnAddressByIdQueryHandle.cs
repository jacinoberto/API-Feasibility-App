using Application.CQRS.AddressCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.AddressCQRS.Handles;

public class ReturnAddressByIdQueryHandle(IAddressRepository repository) : IRequestHandler<ReturnAddressByIdQuery, Address>
{
    private readonly IAddressRepository _repository = repository;
    
    public async Task<Address> Handle(ReturnAddressByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}