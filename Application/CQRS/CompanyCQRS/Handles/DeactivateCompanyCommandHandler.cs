using Application.CQRS.CompanyCQRS.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Handles;

public class DeactivateCompanyCommandHandler(ICompanyRepository repository) : IRequestHandler<DeactivateCompanyCommand, bool>
{
    private readonly ICompanyRepository _repository = repository;
    
    public async Task<bool> Handle(DeactivateCompanyCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return true;
    }
}