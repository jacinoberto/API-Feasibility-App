namespace Application.Utils.ValidationErrors;

public class InternalErrorModel
{
    public double StatusCode { get; set; }
    public string Info { get; set; }
    public string Message { get; set; }

    public InternalErrorModel() { Info = "erro"; }

    public InternalErrorModel(double statusCode, string message)
    {
        StatusCode = statusCode;
        Info = "erro";
        Message = message;
    }
}