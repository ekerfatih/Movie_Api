using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers {
    public class GetCastQueryHandler(MovieContext context) : IRequestHandler<GetCastQuery, List<GetCastQueryResult>> {
        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken) {
            return await context.Casts
                .AsNoTracking()
                .Select(c => new GetCastQueryResult {
                    Biography = c.Biography,
                    CastId = c.CastId,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    Overview = c.Overview,
                    Surname = c.Surname,
                    Title = c.Title
                })
                .ToListAsync(cancellationToken);
        }
    }
}
