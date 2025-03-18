using System.Runtime.CompilerServices;
using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Domain.Utils.Validations;

public class ValidateState
{
    public static void IsValid(string uf)
    {
        StateIsValid(uf);
    }

    private static void StateIsValid(string uf)
    {
        InvalidDataException.When(string.IsNullOrEmpty(uf), "O estado é um campo obrigatório.");
        InvalidDataException.When(uf.Length < 2, "O estado não pode conter menos de 2 caracteres, informe o UF.");
        InvalidDataException.When(uf.Length > 2, "O estado não pode conter mais de 2 caracteres, informe apenas o UF.");
    }
}