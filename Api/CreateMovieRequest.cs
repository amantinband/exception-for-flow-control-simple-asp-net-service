namespace Playground.Api;

public record CreateMovieRequest(string Name, List<string> Actors, bool IsHidden = false);
