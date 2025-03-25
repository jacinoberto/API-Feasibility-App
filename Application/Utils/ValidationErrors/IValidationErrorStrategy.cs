namespace Application.Utils.ValidationErrors;

public interface IValidationErrorStrategy
{
    InternalErrorModel Validate(Exception exception);
}