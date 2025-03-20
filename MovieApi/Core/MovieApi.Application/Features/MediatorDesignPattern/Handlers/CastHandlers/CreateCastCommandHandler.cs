using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers {
    public class CreateCastCommandHandler(MovieContext context) : IRequestHandler<CreateCastCommand> {

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken) {
            bool categoryExists = await context.Casts
            .AsNoTracking()
            .AnyAsync(c => c.Title == request.Title);

            if (categoryExists)
                throw new InvalidOperationException($"Cast '{request.Title}' already exists.");

            var cast = new Cast {
                Biography = request.Biography,
                Overview = request.Overview,
                ImageUrl = request.ImageUrl,
                Surname = request.Surname,
                Title = request.Title,
                Name = request.Name
            };

            await context.Casts.AddAsync(cast);
            await context.SaveChangesAsync();
        }
    }
}
