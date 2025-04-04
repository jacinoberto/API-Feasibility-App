﻿namespace Domain.Entities;

public class FeasibilityType
{
    public Guid Id { get; init; }
    public string Type { get; init; }
    
    /*__Relationships__*/
    public IEnumerable<ViabilityRule> ViabilityRules { get; set; }
    
    private FeasibilityType() { }

    public FeasibilityType(string type)
    {
        Type = type;
    }
}