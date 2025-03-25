using InvalidDataException = Domain.Exceptions.InvalidDataException;

namespace Application.Utils.ValidationErrors.Impl;

public class ValidateDataInvalidError : IValidationErrorStrategy
{
    public InternalErrorModel Validate(Exception exception)
    {
        InternalErrorModel error = new();
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(InvalidDataException))
        {
            error.StatusCode = 400;
            error.Message = exception.Message;
        }

        return error;
    }
}