using Domain.Entities;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Commands;

public class DeactivateCompanyCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; set; } = id;
}