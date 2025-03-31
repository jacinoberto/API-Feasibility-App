using System.Text.Json.Serialization;
using Domain.Utils.Validations;
using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class State
{
    public Guid Id { get; init; }
    public string Uf { get; init; }
    
    /*__Relationships__*/
    [JsonIgnore]
    public IEnumerable<Address> Addresses { get; set; }
    public IEnumerable<RegionConsultation> RegionConsultations { get; set; }
    public IEnumerable<ViabilityState> ViabilityStates { get; set; }
    
    private State(){}

    public State(string uf)
    {
        this.Uf = uf;
    }
}

public class StateFactory
{
    public static State Factory(string uf)
    {
        ValidateState.IsValid(uf);
            
        return new State(uf);
    }
}