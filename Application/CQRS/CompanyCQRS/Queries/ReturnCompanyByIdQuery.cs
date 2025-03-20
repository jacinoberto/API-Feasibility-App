using Domain.Entities;
using MediatR;

namespace Application.CQRS.CompanyCQRS.Queries;

public class ReturnCompanyByIdQuery(Guid id) : IRequest<Company>
{
    public Guid Id { get; set; } = id;
}