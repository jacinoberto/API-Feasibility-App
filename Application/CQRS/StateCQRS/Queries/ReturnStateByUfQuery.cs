using Domain.Entities;
using MediatR;

namespace Application.CQRS.StateCQRS.Queries;

public class ReturnStateByUfQuery(string? uf) : IRequest<State>
{
    public string Uf { get; set; } = uf;
}