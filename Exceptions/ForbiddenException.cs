namespace Playground.Exceptions;

public abstract class ForbiddenException(string errorMessage)
    : ServiceException(StatusCodes.Status403Forbidden, errorMessage);
