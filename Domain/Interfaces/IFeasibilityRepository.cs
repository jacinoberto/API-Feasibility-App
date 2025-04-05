using Domain.Entities;

namespace Domain.Interfaces;

public interface IFeasibilityRepository
{
    Task<Feasibility> CreateAsync(Feasibility entity);
    Task<bool> CheckByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId);
    Task<bool> CheckByZipCodeAsync(string zipCode, Guid companyId, Guid operatorId);
    Task<bool> CheckByCityAsync(string city, Guid companyId, Guid operatorId);
    Task<bool> CheckByAddressAsync(string street, string city, string area, Guid companyId, Guid operatorId);
}