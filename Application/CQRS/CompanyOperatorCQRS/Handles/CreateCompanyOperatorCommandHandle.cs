using Application.CQRS.CompanyOperatorCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.CompanyOperatorCQRS.Handles;

public class CreateCompanyOperatorCommandHandle(ICompanyOperatorRepository repository) 
    : IRequestHandler<CreateCompanyOperatorCommand, bool>
{
    private readonly ICompanyOperatorRepository _repository = repository;
    
    public async Task<bool> Handle(CreateCompanyOperatorCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new CompanyOperator(request.CompanyId, request.OperatorId));
        return true;
    }
}