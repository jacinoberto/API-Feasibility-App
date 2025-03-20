using Domain.Entities;
using MediatR;

namespace Application.CQRS.InternetCQRS.Queries;

public class ReturnInternetByIdQuery(
    Guid id
    ) : IRequest<Internet>
{
    public Guid Id { get; set; } = id;
}