namespace Playground.Exceptions;

public class InternalServerErrorException(string errorMessage)
    : ServiceException(StatusCodes.Status500InternalServerError, errorMessage);
