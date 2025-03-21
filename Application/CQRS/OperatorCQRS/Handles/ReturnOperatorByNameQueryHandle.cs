using Application.CQRS.OperatorCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Handles;

public class ReturnOperatorByNameQueryHandle(IOperatorRepository repository)
    : IRequestHandler<ReturnOperatorByNameQuery, Operator?>
{
    private readonly IOperatorRepository _repository = repository;
    
    public async Task<Operator?> Handle(ReturnOperatorByNameQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByNameAsync(request.OperatorName);
    }
}