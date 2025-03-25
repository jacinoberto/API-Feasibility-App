using Domain.Utils.Validations;
using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class State
{
    public Guid Id { get; init; }
    public string Uf { get; init; }
    
    /*__Relationships__*/
    public IEnumerable<Address> Addresses { get; init; }
    public IEnumerable<RegionConsultation> RegionConsultations { get; init; }
    
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