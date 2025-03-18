using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Utils.Validations;

public class ValidateInternet
{
    public static void Validation(int? internetSpeed, string speedType)
    {
        InternetSpeedIsValid(internetSpeed);
        SpeedTypeIsValid(speedType);
    }

    private static void InternetSpeedIsValid(int? internetSpeed)
    {
        InvalidDataException.When(!internetSpeed.HasValue, "A velocidade de internet é uma informação obrigatória.");
        InvalidDataException.When(internetSpeed <= 0, "A velocidade de internet não pode ser menor ou igual a 0, por favor informe um numéro valido.");
    }

    private static void SpeedTypeIsValid(string speedType)
    {
        InvalidDataException.When(string.IsNullOrEmpty(speedType), "É preciso informar qual o tipo de velicidade da internet (MG, GB).");
        InvalidDataException.When(speedType.Length > 2, "O tipo de velocidade não pode ter mais e 2 caracteres.");
    }
}