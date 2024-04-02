using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Playground.Api;
using Playground.Clients;
using Playground.Exceptions;
using Playground.Persistence;
using Playground.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<MoviesService>();
    builder.Services.AddScoped<MoviesRepository>();
    builder.Services.AddSingleton<RestDatabaseClient>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.MapPost("movies", (CreateMovieRequest request, MoviesService moviesService) =>
    {
        var movie = moviesService.CreateMovie(request.Name, request.Actors, request.IsHidden);

        return Results.CreatedAtRoute(
            routeName: "GetMovie",
            routeValues: new { MovieId = movie.Id },
            value: movie);
    });

    app.MapGet("movies/{movieId:guid}", (Guid movieId, MoviesService moviesService) =>
        Results.Ok(moviesService.GetMovie(movieId))).WithName("GetMovie");

    app.Map("error", (HttpContext context) =>
    {
        var exception = context.Features.GetRequiredFeature<IExceptionHandlerFeature>().Error;

        return exception switch
        {
            ServiceException serviceException => Results.Problem(statusCode: serviceException.StatusCode, detail: serviceException.ErrorMessage),
            _ => Results.Problem()
        };
    });

    app.Run();
}
