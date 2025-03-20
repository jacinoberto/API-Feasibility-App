using Application.CQRS.OperatorCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Handles;

public class ReturnAllOperatorsQueryHandle(IOperatorRepository repository) : IRequestHandler<ReturnAllOperatorQuery, IEnumerable<Operator>>
{
    private readonly IOperatorRepository _repository = repository;
    
    public async Task<IEnumerable<Operator>> Handle(ReturnAllOperatorQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}