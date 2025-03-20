using Domain.Entities;
using MediatR;

namespace Application.CQRS.AddressCQRS.Queries;

public class ReturnAddressByIdQuery(Guid id) : IRequest<Address>
{
    public Guid Id { get; set; } = id;
}