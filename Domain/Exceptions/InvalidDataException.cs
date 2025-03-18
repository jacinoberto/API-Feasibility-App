namespace Domain.Exceptions;

public class InvalidDataException : Exception
{
    public InvalidDataException(string message)
        : base(message) {}

    public static void When(bool hasError, string message)
    {
        if (hasError) throw new InvalidDataException(message);
    }
}