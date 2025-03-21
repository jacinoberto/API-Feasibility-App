using Application.CQRS.InternetCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.InternetCQRS.Handle;

public class ReturnInternetByInternetSpeedQueryHandle(IInternetRepository repository)
    : IRequestHandler<ReturnInternetByInternetSpeedQuery, Internet>
{
    private readonly IInternetRepository _repository = repository;
    
    public async Task<Internet> Handle(ReturnInternetByInternetSpeedQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByInternetSpeedAsync(request.InternetSpeed);
    }
}