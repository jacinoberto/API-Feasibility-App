namespace Domain.Entities;

public class ViabilityRule
{
    public Guid Id { get; init; }
    public Guid PlanId { get; init; }
    public Guid CompanyId { get; init; }
    public Guid FeasibilityTypeId { get; init; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public Plan Plan { get; set; }
    public Company Company { get; set; }
    public FeasibilityType FeasibilityType { get; set; }
    public IEnumerable<ViabilityState> ViabilityStates { get; set; }
    public IEnumerable<ViabilityCity> ViabilityCities { get; set; }
    
    private ViabilityRule() {}
    
    public ViabilityRule(Guid planId, Guid companyId, Guid feasibilityTypeId)
    {
        PlanId = planId;
        CompanyId = companyId;
        FeasibilityTypeId = feasibilityTypeId;
    }
}