using Application.CQRS.InternetCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.InternetCQRS.Handle;

public class CreateInternetCommandHandle(IInternetRepository repository) : IRequestHandler<CreateInternetCommand, bool>
{
    private readonly IInternetRepository _repository = repository;
    
    public async Task<bool> Handle(CreateInternetCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Internet(request.InternetSpeed, request.SpeedType));
        return true;
    }
}