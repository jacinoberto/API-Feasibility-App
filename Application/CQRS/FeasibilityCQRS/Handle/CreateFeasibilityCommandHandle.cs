using Application.CQRS.FeasibilityCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.FeasibilityCQRS.Handle;

public class CreateFeasibilityCommandHandle(IFeasibilityRepository repository) 
    : IRequestHandler<CreateFeasibilityCommand, Feasibility>
{
    private readonly IFeasibilityRepository _repository = repository;
    
    public async Task<Feasibility> Handle(CreateFeasibilityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Feasibility(request.OperatorId, request.AddressId));
    }
}