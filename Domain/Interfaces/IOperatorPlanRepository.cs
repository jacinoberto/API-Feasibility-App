using Domain.Entities;

namespace Domain.Interfaces;

public interface IOperatorPlanRepository
{
    Task<OperatorPlan> CreateAsync(OperatorPlan entity);
    Task<IEnumerable<OperatorPlan>> GetByOperatorIdAsync(Guid operatorId);
}