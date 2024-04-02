using Playground.Exceptions;
using Throw;

namespace Playground.Domain;

public class Movie
{
    public Guid Id { get; }
    public string Name { get; }
    public List<string> Actors { get; }
    public bool IsHidden { get; }

    public Movie(string name, List<string> actors, bool isHidden = false, Guid? id = null)
    {
        Name = name.Throw()
            .IfLongerThan(15)
            .IfShorterThan(3);

        Actors = actors.Throw()
            .IfEmpty()
            .IfTrue(actors => actors.Distinct().Count() != actors.Count);

        IsHidden = isHidden;

        Id = id ?? Guid.NewGuid();
    }
}
