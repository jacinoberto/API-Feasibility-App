using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class Operator
{
    public Guid Id { get; init; }
    public string OperatorName { get; init; }
    public bool IsActive { get; private set; }
    
    /*Relationships*/
    public IEnumerable<CompanyOperator> CompaniesOperators { get; set; }
    public IEnumerable<Feasibility> Feasibilities { get; set; }
    
    private Operator() {}

    public Operator(string operatorName)
    {
        OperatorName = operatorName;
        IsActive = true;
    }

    public void DeactivateOperator()
    {
        IsActive = false;
    }
}

public class OperatorFactory
{
    public static Operator Factory(string operatorName)
    {
        InvalidDataException.When(string.IsNullOrEmpty(operatorName), "O nome da operadora é uma informação obrigatória.");
        
        return new Operator(operatorName);
    }
}