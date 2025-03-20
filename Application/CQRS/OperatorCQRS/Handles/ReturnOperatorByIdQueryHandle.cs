using Application.CQRS.OperatorCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Handles;

public class ReturnOperatorByIdQueryHandle(IOperatorRepository repository) : IRequestHandler<ReturnOperatorByIdQuery, Operator>
{
    private readonly IOperatorRepository _repository = repository;
    
    public async Task<Operator> Handle(ReturnOperatorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id); 
    }
}