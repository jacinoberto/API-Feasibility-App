using MediatR;

namespace Application.CQRS.OperatorCQRS.Commands;

public class CreateOperatorCommand(string operatorName) : IRequest<bool>
{
    public string OperatorName { get; set; } = operatorName;
}