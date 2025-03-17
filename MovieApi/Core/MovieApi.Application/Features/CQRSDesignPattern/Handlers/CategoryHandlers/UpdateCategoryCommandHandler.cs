using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers {
    public class UpdateCategoryCommandHandler(MovieContext context) {
        public async Task<bool> Handle(UpdateCategoryCommand command) {
            var category = await context.Categories.FindAsync(command.CategoryId)
                ?? throw new KeyNotFoundException($"Category with ID {command.CategoryId} not found.");

            category.CategoryName = command.CategoryName;

            return await context.SaveChangesAsync() > 0;
        }
    }
}
