using Application.CQRS.PlanObservationCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.PlanObservationCQRS.Handle;

public class ReturnPlanObservationByPlanIdQueryHandle(IPlanObservationRepository repository)
    : IRequestHandler<ReturnPlanObservationByPlanIdQuery, IEnumerable<PlanObservation>>
{
    private readonly IPlanObservationRepository _repository = repository;
    
    public async Task<IEnumerable<PlanObservation>> Handle(ReturnPlanObservationByPlanIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByPlanIdAsync(request.PlanId);
    }
}