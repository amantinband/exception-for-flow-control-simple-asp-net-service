namespace Playground.Exceptions;

public class HiddenMovieException(Guid movieId)
    : ForbiddenException($"Hidden movie cannot be accessed or manipulated (movie id: {movieId})");
