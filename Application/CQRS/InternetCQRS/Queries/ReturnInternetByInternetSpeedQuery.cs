using Domain.Entities;
using MediatR;

namespace Application.CQRS.InternetCQRS.Queries;

public class ReturnInternetByInternetSpeedQuery(int internetSpeed)
    : IRequest<Internet>
{
    public int InternetSpeed { get; set; } = internetSpeed;
}