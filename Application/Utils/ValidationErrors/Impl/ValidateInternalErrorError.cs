using Domain.Exceptions;

namespace Application.Utils.ValidationErrors.Impl;

public class ValidateInternalErrorError : IValidationErrorStrategy
{
    public InternalErrorModel Validate(Exception exception)
    {
        InternalErrorModel error = new();
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(InternalErrorException))
        {
            error.StatusCode = 500;
            error.Message = exception.Message;
        }

        return error;
    }
}