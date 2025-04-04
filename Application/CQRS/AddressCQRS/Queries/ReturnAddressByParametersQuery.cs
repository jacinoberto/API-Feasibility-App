﻿using Domain.Entities;
using MediatR;

namespace Application.CQRS.AddressCQRS.Queries;

public class ReturnAddressByParametersQuery(
    string? zipCode,
    string? city,
    string? state
    ) : IRequest<Address>
{
    public string ZipCode { get; set; } = zipCode;
    public string City { get; set; } = city;
    public string State { get; set; } = state;
}