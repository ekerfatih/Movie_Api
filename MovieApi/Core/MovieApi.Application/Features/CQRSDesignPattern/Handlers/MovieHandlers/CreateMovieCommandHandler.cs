using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers {
    public class CreateMovieCommandHandler(MovieContext context) {
        public async Task Handle(CreateMovieCommand command) {
            var movieExists = await context.Movies
                .AsNoTracking()
                .AnyAsync(m => m.Title == command.Title);

            if (movieExists)
                throw new InvalidOperationException($"A movie with the title '{command.Title}' already exists.");

            var newMovie = new Movie {
                Title = command.Title,
                CoverImage = command.CoverImage,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate,
                CreatedDate = command.CreatedDate,
                Status = command.Status
            };

            await context.Movies.AddAsync(newMovie);
            await context.SaveChangesAsync();
        }
    }
}
