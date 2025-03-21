using Application.CQRS.InternetCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.InternetCQRS.Handle;

public class CreateInternetCommandHandle(IInternetRepository repository) : IRequestHandler<CreateInternetCommand, Internet>
{
    private readonly IInternetRepository _repository = repository;
    
    public async Task<Internet> Handle(CreateInternetCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new Internet(request.InternetSpeed, request.SpeedType));
    }
}