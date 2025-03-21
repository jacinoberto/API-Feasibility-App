using Application.CQRS.OperatorCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Handles;

public class CreateOperatorCommandHandle(IOperatorRepository repository) : IRequestHandler<CreateOperatorCommand, Operator>
{
    private readonly IOperatorRepository _repository = repository;
    
    public async Task<Operator> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Operator(request.OperatorName));
    }
}