namespace Domain.Entities;

public class Observation
{
    public Guid Id { get; init; }
    public string PlanObservation { get; private set; }
    
    /*__Relationships__*/
    public IEnumerable<PlanObservation> PlanObservations { get; set; }
    
    private Observation() { }

    public Observation(string planObservation)
    {
        PlanObservation = planObservation;
    }

    public void Alter(string planObservation)
    {
        PlanObservation = planObservation;
    }
}