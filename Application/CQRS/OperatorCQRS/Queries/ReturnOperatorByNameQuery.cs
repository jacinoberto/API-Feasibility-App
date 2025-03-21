using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Queries;

public class ReturnOperatorByNameQuery(string operatorName) : IRequest<Operator>
{
    public string OperatorName { get; set; } = operatorName;
}