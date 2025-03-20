using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Queries;

public class ReturnOperatorByIdQuery(Guid id) : IRequest<Operator>
{
    public Guid Id { get; set; } = id;
}