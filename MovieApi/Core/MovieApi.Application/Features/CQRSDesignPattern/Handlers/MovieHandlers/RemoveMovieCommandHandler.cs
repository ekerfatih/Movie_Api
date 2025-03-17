using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers {
    public class RemoveMovieCommandHandler(MovieContext context) {
        public async Task<bool> Handle(RemoveMovieCommand command) {
            var movie = await context.Movies.FindAsync(command.MovieId)
                ?? throw new KeyNotFoundException($"Movie with ID {command.MovieId} not found.");

            context.Movies.Remove(movie);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
