using Domain.Entities;
using MediatR;

namespace Application.CQRS.AddressCQRS.Queries;

public class ReturnAddressesByStateQuery(string state) : IRequest<IEnumerable<Address>>
{
    public string State { get; set; } = state;
}