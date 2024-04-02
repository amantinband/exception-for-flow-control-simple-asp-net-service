namespace Playground.Exceptions;

public class ServiceException(int statusCode, string errorMessage) : Exception
{
    public int StatusCode { get; } = statusCode;
    public string ErrorMessage { get; } = errorMessage;
}

