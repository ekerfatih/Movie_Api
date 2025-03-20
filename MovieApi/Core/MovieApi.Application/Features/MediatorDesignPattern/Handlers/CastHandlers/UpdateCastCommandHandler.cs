using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers {
    public class UpdateCastCommandHandler(MovieContext context) : IRequestHandler<UpdateCastCommand> {
        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken) {
            var cast = await context.Casts.FindAsync(request.CastId)
                ?? throw new KeyNotFoundException($"Cast with ID {request.CastId} not found.");

            cast.Overview = request.Overview;
            cast.Surname = request.Surname;
            cast.Biography = request.Biography;
            cast.ImageUrl = request.ImageUrl;
            cast.Name = request.Name;
            cast.Title = request.Title;

            await context.SaveChangesAsync();
        }
    }
}
