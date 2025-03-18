using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Utils.Validations;

public class ValidatePlan
{
    public static void Validation(Guid internetId, string planName, decimal value)
    {
        InternetIdIsValid(internetId);
        PlanNameIsValid(planName);
        ValueIsValid(value);
    }

    private static void InternetIdIsValid(Guid internetId)
    {
        InvalidDataException.When(string.IsNullOrEmpty(internetId.ToString()), "É preciso informar qual internet pertence ao plano.");
    }

    private static void PlanNameIsValid(string planName)
    {
        InvalidDataException.When(string.IsNullOrEmpty(planName), "O nome do plano é uma informação obrigatória.");
    }

    private static void ValueIsValid(decimal value)
    {
        InvalidDataException.When(value <= 0, "O valor do plano não pode ser menor ou igual a 0, informe um valor valido.");
    }
}