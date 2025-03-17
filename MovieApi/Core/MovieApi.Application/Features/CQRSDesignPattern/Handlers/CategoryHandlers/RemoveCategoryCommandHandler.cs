using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers {
    public class RemoveCategoryCommandHandler(MovieContext context) {
        public async Task<bool> Handle(RemoveCategoryCommand command) {
            var category = await context.Categories.FindAsync(command.CategoryId)
                ?? throw new KeyNotFoundException($"Category with ID {command.CategoryId} not found.");

            context.Categories.Remove(category);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
