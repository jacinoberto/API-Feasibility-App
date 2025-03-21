using Application.CQRS.AddressCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.AddressCQRS.Handles;

public class ReturnAddressByParametersQueryHandle(IAddressRepository repository)
    : IRequestHandler<ReturnAddressByParametersQuery, Address>
{
    private readonly IAddressRepository _repository = repository;
    
    public async Task<Address> Handle(ReturnAddressByParametersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByParameters(request.ZipCode, request.City, request.State);
    }
}