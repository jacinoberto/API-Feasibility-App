using Domain.Utils.Validations;

namespace Domain.Entities;

public class Address
{
    public Guid Id { get; init; }
    public Guid? StateId { get; init; }
    public string? ZipCode { get; init; }
    public string? Street { get; init; }
    public int? Number { get; init; }
    public string? Area { get; init; }
    public string? City { get; init; }
    
    public State? State { get; set; }
    
    /*Relationships*/
    public IEnumerable<PlanFeasibility> PlanFeasibility { get; set; }
    private Address() { }
    
    public Address(Guid? stateId, string? zipCode, string? street, int? number, string? area, string? city)
    {
        StateId = stateId;
        ZipCode = zipCode;
        Street = street;
        Number = number;
        Area = area;
        City = city;
    }
}

public class AddressFactory
{
    public static Address Create(Guid? stateId, string? zipCode, string? street, int? number, string? area, string? city)
    {
        ValidateZipCode.Validation(zipCode, street, number, area, city);
            
        return new Address(stateId, zipCode, street, number, area, city);
    }
}

