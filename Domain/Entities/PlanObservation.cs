namespace Domain.Entities;

public class PlanObservation
{
    public Guid Id { get; init; }
    public Guid PlanId { get; init; }
    public Guid ObservationId { get; init; }
    public bool IsActive { get; init; }
    
    /*__Relationships__*/
    public Plan Plan { get; set; }
    public Observation Observation { get; set; }
    
    private PlanObservation() {}

    public PlanObservation(Guid planId, Guid observationId)
    {
        PlanId = planId;
        ObservationId = observationId;
        IsActive = true;
    }
}