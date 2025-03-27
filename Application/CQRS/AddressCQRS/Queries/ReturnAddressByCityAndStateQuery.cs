using Domain.Entities;
using MediatR;

namespace Application.CQRS.AddressCQRS.Queries;

public class ReturnAddressByCityAndStateQuery(string city, string state) : IRequest<Address>
{
    public string City { get; set; } = city;
    public string State { get; set; } = state;
}