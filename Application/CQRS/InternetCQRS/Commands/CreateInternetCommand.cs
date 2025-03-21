using Domain.Entities;
using MediatR;

namespace Application.CQRS.InternetCQRS.Commands;

public class CreateInternetCommand(
    int internetSpeed,
    string speedType
    ) : IRequest<Internet>
{
    public int InternetSpeed { get; set; } = internetSpeed;
    public string SpeedType { get; set; } = speedType;
}