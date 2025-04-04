﻿namespace Domain.Entities;

public class ViabilityState
{
    public Guid Id { get; init; }
    public Guid ViabilityRuleId { get; init; }
    public Guid StateId { get; init; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public ViabilityRule ViabilityRule { get; set; }
    public State State { get; set; }
    
    private ViabilityState() {}

    public ViabilityState(Guid viabilityRuleId, Guid stateId)
    {
        ViabilityRuleId = viabilityRuleId;
        StateId = stateId;
        IsActive = true;
    }

    public void Disable()
    {
        IsActive = false;
    }
}