using Playground.Clients;
using Playground.Domain;
using Playground.Exceptions;

namespace Playground.Persistence;

public class MoviesRepository(RestDatabaseClient _restDatabaseClient)
{
    public void AddMovie(Movie movie)
    {
        _restDatabaseClient.StoreObject(movie.Id, movie);
    }

    public Movie GetMovie(Guid id)
    {
        return _restDatabaseClient.GetObject<Movie>(id) ?? throw new NotFoundException($"Movie not found (movie id: {id}");
    }
}
