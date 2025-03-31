using Application.CQRS.AddressCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.AddressCQRS.Handles;

public class ReturnAddressesByStateQueryHandle(IAddressRepository repository)
    : IRequestHandler<ReturnAddressesByStateQuery, IEnumerable<Address>>
{
    private readonly IAddressRepository _repository = repository;
    
    public async Task<IEnumerable<Address>> Handle(ReturnAddressesByStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByStateAsync(request.State);
    }
}