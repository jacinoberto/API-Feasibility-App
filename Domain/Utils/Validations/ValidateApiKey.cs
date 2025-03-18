using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Utils.Validations;

public class ValidateApiKey
{
    public static void Validation(Guid companyId, string apiKey)
    {
        CompanyIdIsValid(companyId);
        ApiKeyIsValid(apiKey);
    }

    private static void CompanyIdIsValid(Guid companyId)
    {
        InvalidDataException.When(string.IsNullOrEmpty(companyId.ToString()), "A chave de API precisa ser vinculada a uma empresa valida, informe um ID valido!");
    }

    private static void ApiKeyIsValid(string apiKey)
    {
        InvalidDataException.When(string.IsNullOrEmpty(apiKey), "A chave de API é uma informação obrigatória.");
    }
}