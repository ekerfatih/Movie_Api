using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers {
    public class RemoveCastCommandHandler(MovieContext context) : IRequestHandler<RemoveCastCommand> {
        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken) {
            var cast = await context.Casts.FindAsync(request.CastId)
                ?? throw new KeyNotFoundException($"Cast with ID {request.CastId} not found.");

            context.Casts.Remove(cast);
            await context.SaveChangesAsync();
        }
    }
}
