using Application.CQRS.PlanObservationCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanObservationCQRS.Handle;

public class CreatePlanObservationCommandHandle(IPlanObservationRepository repository) 
    : IRequestHandler<CreatePlanObservationCommand, PlanObservation>
{
    private readonly IPlanObservationRepository _repository = repository;
    
    public async Task<PlanObservation> Handle(CreatePlanObservationCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new PlanObservation(request.PlanId, request.ObservationId));
    }
}