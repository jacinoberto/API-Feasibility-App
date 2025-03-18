using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Entities;

public class CompanyOperator
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public Guid OperatorId { get; init; }
    
    /*__Relationships__*/
    public Company Company { get; set; }
    public Operator Operator { get; set; }
    
    private CompanyOperator() { }

    public CompanyOperator(Guid companyId, Guid operatorId)
    {
        CompanyId = companyId;
        OperatorId = operatorId;
    }
}

public class CompanyOperatorFactory
{
    public static CompanyOperator Factory(Guid companyId, Guid operatorId)
    {
        InvalidDataException.When(string.IsNullOrEmpty(companyId.ToString()), "No vinculo com uma operadora o ID da empresa precisa ser informado!");
        InvalidDataException.When(string.IsNullOrEmpty(operatorId.ToString()), "No vinculo com uma empresa o ID da operadora precisa ser informado!");
        return new CompanyOperator(companyId, operatorId);
    }
}