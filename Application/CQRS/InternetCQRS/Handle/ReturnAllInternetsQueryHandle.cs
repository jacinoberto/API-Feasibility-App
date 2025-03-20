using Application.CQRS.InternetCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.InternetCQRS.Handle;

public class ReturnAllInternetsQueryHandle(IInternetRepository repository) : IRequestHandler<ReturnAllInternetsQuery, IEnumerable<Internet>>
{
    private readonly IInternetRepository _repository = repository;
    
    public async Task<IEnumerable<Internet>> Handle(ReturnAllInternetsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}