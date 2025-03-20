using Application.CQRS.InternetCQRS.Commands;
using Application.CQRS.InternetCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.InternetCQRS.Handle;

public class ReturnInternetByIdQueryHandle(IInternetRepository repository) : IRequestHandler<ReturnInternetByIdQuery, Internet>
{
    private readonly IInternetRepository _repository = repository;

    public async Task<Internet> Handle(ReturnInternetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}