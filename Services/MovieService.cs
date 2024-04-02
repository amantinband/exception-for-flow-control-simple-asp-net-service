using Playground.Domain;
using Playground.Exceptions;
using Playground.Persistence;

namespace Playground.Services;

public class MoviesService(MoviesRepository _moviesRepository)
{
    public Movie CreateMovie(string name, List<string> actors, bool isHidden)
    {
        var movie = new Movie(name, actors, isHidden);

        _moviesRepository.AddMovie(movie);

        return movie;
    }

    public Movie GetMovie(Guid id)
    {
        var movie = _moviesRepository.GetMovie(id);

        return movie.IsHidden
            ? throw new HiddenMovieException(id)
            : movie;
    }
}
