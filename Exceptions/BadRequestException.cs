namespace Playground.Exceptions;

public abstract class BadRequestException(string errorMessage)
    : ServiceException(StatusCodes.Status400BadRequest, errorMessage);
