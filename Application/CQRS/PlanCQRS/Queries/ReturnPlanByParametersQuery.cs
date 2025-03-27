using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanCQRS.Queries;

public class ReturnPlanByParametersQuery(string plan, decimal value, Guid internetId) : IRequest<Plan?>
{
    public string Plan { get; set; } = plan;
    public decimal Value { get; set; } = value;
    public Guid InternetId { get; set; } = internetId;
}