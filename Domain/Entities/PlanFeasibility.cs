using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class PlanFeasibility
{
    public Guid Id { get; init; }
    public Guid OperatorPlanId { get; init; }
    public Guid AddressId { get; init; }

    /*__Relationships__*/
    public OperatorPlan OperatorPlan { get; set; }
    public Address Address { get; set; }
    
    private PlanFeasibility() { }
    
    public PlanFeasibility( Guid operatorPlanId, Guid addressId)
    {
        OperatorPlanId = operatorPlanId;
        AddressId = addressId;
    }
}

public class PlanFeasibilityFactory
{
    public static PlanFeasibility Factory(Guid operatorPlanId, Guid addressId)
    {
        InvalidDataException.When(string.IsNullOrEmpty(operatorPlanId.ToString()), "O ID da operadora é obrigatório para vinculo com endereço.");
        InvalidDataException.When(string.IsNullOrEmpty(addressId.ToString()), "O ID do endereço é obrigatório para vinculo com operadora.");
        return new PlanFeasibility(operatorPlanId, addressId);
    }
}