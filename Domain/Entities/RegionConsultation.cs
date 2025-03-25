namespace Domain.Entities;

public class RegionConsultation
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public Guid StateId { get; init; }
    
    /*__Relationships__*/
    public Company Company { get; set; }
    public State State { get; set; }
    
    private RegionConsultation() { }

    public RegionConsultation(Guid companyId, Guid stateId)
    {
        CompanyId = companyId;
        StateId = stateId;
    }
}