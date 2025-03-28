using Domain.Entities;

namespace Domain.Interfaces;

public interface IViabilityRuleRepository
{
    Task<ViabilityRule> CreateAsync(ViabilityRule entity);
    Task<IEnumerable<ViabilityRule>> GetByZipCode(string zipCode, Guid companyId);
    Task<ICollection<ViabilityRule>> GetByCity(string city, Guid companyId);
    Task<IEnumerable<ViabilityRule>> GetByCityAndState(string city, string state, Guid companyId);
    Task DisableAsync(Guid companyId);
}