namespace Domain.Entities;

public class Feasibility
{
    public Guid Id { get; init; }
    public Guid OperatorId { get; init; }
    public Guid AddressId { get; init; }
    
    /*__Relationships__*/
    public Operator Operator { get; set; }
    public Address Address { get; set; }
    
    private Feasibility() { }

    public Feasibility(Guid operatorId, Guid addressId)
    {
        OperatorId = operatorId;
        AddressId = addressId;
    }
}