using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class OperatorPlan
{
    public Guid Id { get; init; }
    public Guid OperatorId { get; init; }
    public Guid PlanId { get; init; }
    
    /*__Relationships__*/
    public Operator Operator { get; set; }
    public Plan Plan { get; set; }
    public IEnumerable<PlanFeasibility> PlanFeasibility { get; set; }
    
    private OperatorPlan() { }

    public OperatorPlan(Guid operatorId, Guid planId)
    {
        OperatorId = operatorId;
        PlanId = planId;
    }
}

public class OperatorPlanFactory
{
    public static OperatorPlan Factory(Guid operatorId, Guid planId)
    {
        InvalidDataException.When(string.IsNullOrEmpty(operatorId.ToString()), "O ID da operadora é obrigatório para vinculo com plano.");
        InvalidDataException.When(string.IsNullOrEmpty(planId.ToString()), "O ID do plano é obrigatório para vinculo com operadora.");
        return new OperatorPlan(operatorId, planId);
    }
}