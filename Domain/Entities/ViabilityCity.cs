namespace Domain.Entities;

public class ViabilityCity
{
    public Guid Id { get; init; }
    public Guid ViabilityRuleId { get; init; }
    public Guid AddressId { get; init; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public ViabilityRule ViabilityRule { get; set; }
    public Address Address { get; set; }
    
    private ViabilityCity() {}

    public ViabilityCity(Guid viabilityRuleId, Guid addressId)
    {
        ViabilityRuleId = viabilityRuleId;
        AddressId = addressId;
        IsActive = true;
    }

    public void Disable()
    {
        IsActive = false;
    }
}