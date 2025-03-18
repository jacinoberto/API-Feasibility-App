using Domain.Utils.Validations;

namespace Domain.Entities;

public class Internet
{
    public Guid Id { get; init; }
    public int InternetSpeed  { get; init; }
    public string SpeedType { get; init; }
    
    /*__Relationships__*/
    public IEnumerable<Plan> Plans  { get; set; }
    
    private Internet() { }

    public Internet(int internetSpeed, string speedType)
    {
        InternetSpeed = internetSpeed;
        SpeedType = speedType;
    }
}

public class InternetFactory
{
    public static Internet Factory(int internetSpeed, string speedType)
    {
        ValidateInternet.Validation(internetSpeed, speedType);
        return new Internet(internetSpeed, speedType);
    }
}