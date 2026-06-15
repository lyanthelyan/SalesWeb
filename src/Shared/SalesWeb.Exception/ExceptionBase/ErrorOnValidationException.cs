namespace SalesWeb.Exceptions.ExceptionBase;

public class ErrorOnValidationException : SalesWebException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }

    public List<string> GetErrorMessages()
    {
        return _errors;
    }
}
