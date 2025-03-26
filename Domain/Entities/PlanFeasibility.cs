using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class PlanFeasibility
{
    public Guid Id { get; init; }
    public Guid PlanId { get; init; }
    public Guid FeasibilityId { get; init; }
    public Guid FeasibilityTypeId { get; init; }
    public bool IsActive { get; private set; }

    /*__Relationships__*/
    public Plan Plan { get; set; }
    public Feasibility Feasibility { get; set; }
    public FeasibilityType FeasibilityType { get; set; }
    
    private PlanFeasibility() { }
    
    public PlanFeasibility( Guid planId, Guid feasibilityId, Guid feasibilityTypeId)
    {
        PlanId = planId;
        FeasibilityId = feasibilityId;
        FeasibilityTypeId = feasibilityTypeId;
        IsActive = true;
    }
}