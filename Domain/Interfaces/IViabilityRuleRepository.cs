using Domain.Entities;

namespace Domain.Interfaces;

public interface IViabilityRuleRepository
{
    Task<ViabilityRule> CreateAsync(ViabilityRule entity);
}