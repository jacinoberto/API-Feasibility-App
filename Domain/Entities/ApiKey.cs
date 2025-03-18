using Domain.Utils.Validations;

namespace Domain.Entities;

public class ApiKey
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public string Key { get; init; }
    public DateTime Created { get; init; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public Company Company { get; set; }
    
    private ApiKey() {}

    public ApiKey(Guid companyId, string key)
    {
        CompanyId = companyId;
        Key = key;
        Created = DateTime.Now;
        IsActive = true;
    }

    public void DeactivateApiKey()
    {
        IsActive = false;
    }
}

public class ApiKeysFactory
{
    public static ApiKey Factory(Guid companyId, string key)
    {
        ValidateApiKey.Validation(companyId, key);
        
        return new ApiKey(companyId, key);
    }
}