using Domain.Entities;
using MediatR;

namespace Application.CQRS.OperatorCQRS.Commands;

public class CreateOperatorCommand(string operatorName) : IRequest<Operator>
{
    public string OperatorName { get; set; } = operatorName;
}