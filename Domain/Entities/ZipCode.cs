namespace Domain.Entities;

public class ZipCode
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public string Street { get; init; }
    public string Area { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    
    private ZipCode() { }
    
    private ZipCode(Guid id, string code, string street, string area, string city, string state)
    {
        Id = id;
        Code = code;
        Street = street;
        Area = area;
        City = city;
        State = state;
    }
    
    public class ZipCodeFactory
    {
        public static ZipCode Create(Guid id, string code, string street, string area, string city, string state)
        {
            return new ZipCode(id, code, street, area, city, state);
        }
    }
}

