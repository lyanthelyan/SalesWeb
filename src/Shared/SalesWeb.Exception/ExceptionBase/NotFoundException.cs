using SalesWeb.Exceptions.ExceptionBase;

public class NotFoundException : SalesWebException
{
    public NotFoundException(string message) : base(message)
    {
    }
}