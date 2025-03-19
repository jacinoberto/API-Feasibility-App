namespace Domain.Exceptions;

public class InvalidDataException(string message) : Exception(message)
{
    public static void When(bool hasError, string message)
    {
        if (hasError) throw new InvalidDataException(message);
    }
}