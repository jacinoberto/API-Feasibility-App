using Domain.Exceptions;

namespace Application.Utils.ValidationErrors.Impl;

public class ValidateNotFoundError : IValidationErrorStrategy
{
    public InternalErrorModel Validate(Exception exception)
    {
        InternalErrorModel error = new();
        var exceptionType = exception.GetType();

        if (exceptionType == typeof(NotFoundException))
        {
            error.StatusCode = 404;
            error.Message = exception.Message;
        }

        return error;
    }
}