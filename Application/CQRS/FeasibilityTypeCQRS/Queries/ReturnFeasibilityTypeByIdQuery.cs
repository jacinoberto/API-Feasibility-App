using Domain.Entities;
using MediatR;

namespace Application.CQRS.FeasibilityTypeCQRS.Queries;

public class ReturnFeasibilityTypeByIdQuery(Guid id) : IRequest<FeasibilityType>
{
    public Guid Id { get; set; } = id;
}