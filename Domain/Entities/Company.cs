namespace Domain.Entities;

public class Company
{
    public Guid Id { get; init; }
    public string CompanyName { get; private set; }
    public string CompanyCode { get; init; }
    public string ResponsibleContact { get; private set; }
    public string FinancialContact { get; private set; }
    public string ResponsibleEmail { get; private set; }
    public string FinancialEmail { get; private set; }
    public bool IsActive { get; private set; }
    
    /*__Relationships__*/
    public IEnumerable<ApiKey> ApiKeys { get; set; }
    public IEnumerable<CompanyOperator> CompanyOperators { get; set; }
    public IEnumerable<RegionConsultation> RegionConsultations { get; set; }
    
    private Company(){}

    public Company(string companyName, string companyCode, string responsibleContact, string financialContact,
        string responsibleEmail, string financialEmail)
    {
        CompanyName = companyName;
        CompanyCode = companyCode;
        ResponsibleContact = responsibleContact;
        FinancialContact = financialContact;
        ResponsibleEmail = responsibleEmail;
        FinancialEmail = financialEmail;
        IsActive = true;
    }

    public void ChangeCompany(string companyName, string responsibleContact, string financialContact, string responsibleEmail,
        string financialEmail)
    {
        CompanyName = companyName;
        ResponsibleContact = responsibleContact;
        FinancialContact = financialContact;
        ResponsibleEmail = responsibleEmail;
        FinancialEmail = financialEmail;
    }

    public void DeactivateCompany()
    {
        IsActive = false;
    }
}

public class CompanyFactory
{
    public static Company Factory(string companyName, string companyCode, string responsibleContact,
        string financialContact, string responsibleEmail, string financialEmail)
    {
        return new Company(companyName, companyCode, responsibleContact, financialContact, responsibleEmail, financialEmail);
    }
}