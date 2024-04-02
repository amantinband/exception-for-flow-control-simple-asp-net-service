namespace Playground.Exceptions;

public class NotFoundException(string errorMessage)
    : ServiceException(StatusCodes.Status404NotFound, errorMessage);
