using Domain.Entities;
using MediatR;

namespace Application.CQRS.ObservationCQRS.Commands;

public class CreateObservationCommand(string observation) : IRequest<Observation>
{
    public string Observation { get; set; } = observation;
}