using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Quaries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers {
    public class GetMovieByIdQueryHandler(MovieContext context) {
        public async Task<GetMovieByIdQueryResult?> Handle(GetMovieByIdQuery query) {
            return await context.Movies
                .AsNoTracking()
                .Where(x => x.MovieId == query.MovieId)
                .Select(x => new GetMovieByIdQueryResult {
                    CoverImage = x.CoverImage,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Title = x.Title,
                    MovieId = x.MovieId,
                    Duration = x.Duration,
                    Rating = x.Rating,
                    ReleaseDate = x.ReleaseDate,
                    Status = x.Status
                })
                .FirstOrDefaultAsync();
        }
    }
}
