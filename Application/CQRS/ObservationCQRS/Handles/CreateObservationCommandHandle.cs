using Application.CQRS.ObservationCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.ObservationCQRS.Handles;

public class CreateObservationCommandHandle(IObservationRepository repository)
    : IRequestHandler<CreateObservationCommand, Observation>
{
    private readonly IObservationRepository _repository = repository;
    
    public async Task<Observation> Handle(CreateObservationCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Observation(request.Observation));
    }
}