using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers {
    public class GetCastByIdQueryHandler(MovieContext context) : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult?> {
        public async Task<GetCastByIdQueryResult?> Handle(GetCastByIdQuery request, CancellationToken cancellationToken) {
            return await context.Casts
                .AsNoTracking()
                .Where(c => c.CastId == request.CastId)
                .Select(c => new GetCastByIdQueryResult {
                    Biography = c.Biography,
                    CastId = c.CastId,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    Overview = c.Overview,
                    Surname = c.Surname,
                    Title = c.Title
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
