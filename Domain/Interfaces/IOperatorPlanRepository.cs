using Domain.Entities;

namespace Domain.Interfaces;

public interface IOperatorPlanRepository
{
    Task CreateAsync(OperatorPlan entity);
    Task<IEnumerable<OperatorPlan>> GetByOperatorIdAsync(Guid operatorId);
}