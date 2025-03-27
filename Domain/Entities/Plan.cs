using Domain.Utils.Validations;

namespace Domain.Entities;

public class Plan
{
    public Guid Id { get; init; }
    public Guid InternetId { get; init; }
    public string PlanName { get; init; }
    public decimal Value { get; private set; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public Internet Internet { get; set; }
    public IEnumerable<PlanFeasibility> PlanFeasibilities { get; set; }
    public IEnumerable<ViabilityRule> ViabilityRules { get; set; }
    
    private Plan(){}

    public Plan(Guid internetId, string planName, decimal value)
    {
        InternetId = internetId;
        PlanName = planName;
        Value = value;
        IsActive = true;
    }

    public void DeactivatePlan()
    {
        IsActive = false;
    }
}

public class PlanFactory
{
    public static Plan Factory(Guid internetId, string planName, decimal value)
    {
        ValidatePlan.Validation(internetId, planName, value);
        return new Plan(internetId, planName, value);
    }
}