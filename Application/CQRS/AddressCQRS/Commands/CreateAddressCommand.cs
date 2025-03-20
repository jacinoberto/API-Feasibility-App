using Domain.Entities;
using MediatR;

namespace Application.CQRS.AddressCQRS.Commands;

public class CreateAddressCommand(
    Guid? stateId,
    string? zipCode,
    string? street,
    int? number,
    string? area,
    string? city)
    : IRequest<Address>
{
    public Guid? StateId { get; set; } = stateId;
    public string? ZipCode { get; set; } = zipCode;
    public string? Street { get; set; } = street;
    public int? Number { get; set; } = number;
    public string? Area  { get; set; } = area;
    public string? City { get; set; } = city;
}