namespace SalesWeb.Exceptions.ExceptionBase;

public abstract class SalesWebException : System.Exception
{
    protected SalesWebException(string message) : base(message)
    {
    }
}
