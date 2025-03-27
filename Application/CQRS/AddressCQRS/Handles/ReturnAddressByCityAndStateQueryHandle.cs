using Application.CQRS.AddressCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.AddressCQRS.Handles;

public class ReturnAddressByCityAndStateQueryHandle(IAddressRepository repository)
    : IRequestHandler<ReturnAddressByCityAndStateQuery, Address>
{
    private readonly IAddressRepository _repository = repository;
    
    public async Task<Address> Handle(ReturnAddressByCityAndStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCityAndStateAsync(request.City, request.State);
    }
}