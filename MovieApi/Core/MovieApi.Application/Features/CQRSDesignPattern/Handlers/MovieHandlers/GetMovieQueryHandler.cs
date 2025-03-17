using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers {
    public class GetMovieQueryHandler(MovieContext context) {
        public async Task<IReadOnlyList<GetMovieQueryResult>> Handle() {
            return await context.Movies
                .AsNoTracking()
                .Select(x => new GetMovieQueryResult {
                    CoverImage = x.CoverImage,
                    Description = x.Description,
                    Title = x.Title,
                    CreatedDate = x.CreatedDate,
                    Duration = x.Duration,
                    MovieId = x.MovieId,
                    Rating = x.Rating,
                    ReleaseDate = x.ReleaseDate,
                    Status = x.Status
                })
                .ToListAsync();
        }
    }
}
