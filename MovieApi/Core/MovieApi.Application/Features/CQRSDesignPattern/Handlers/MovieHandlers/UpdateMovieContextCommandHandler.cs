using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers {
    public class UpdateMovieCommandHandler(MovieContext context) {
        public async Task<bool> Handle(UpdateMovieCommand command) {
            var movie = await context.Movies.FindAsync(command.MovieId)
                ?? throw new KeyNotFoundException($"Movie with ID {command.MovieId} not found.");

            movie.Title = command.Title;
            movie.CoverImage = command.CoverImage;
            movie.Rating = command.Rating;
            movie.Description = command.Description;
            movie.Duration = command.Duration;
            movie.ReleaseDate = command.ReleaseDate;
            movie.CreatedDate = command.CreatedDate;
            movie.Status = command.Status;

            return await context.SaveChangesAsync() > 0;
        }
    }
}
