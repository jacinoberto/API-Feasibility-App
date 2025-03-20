using Application.CQRS.OperatorCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Handles;

public class CreateOperatorCommandHandle(IOperatorRepository repository) : IRequestHandler<CreateOperatorCommand, bool>
{
    private readonly IOperatorRepository _repository = repository;
    
    public async Task<bool> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Operator(request.OperatorName));
        return true;
    }
}