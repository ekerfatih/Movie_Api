using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers {
    public class CreateCategoryCommandHandler(MovieContext context) {
        public async Task Handle(CreateCategoryCommand command) {
            bool categoryExists = await context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.CategoryName == command.CategoryName);

            if (categoryExists)
                throw new InvalidOperationException($"Category '{command.CategoryName}' already exists.");

            await context.Categories.AddAsync(new Category { CategoryName = command.CategoryName });
            await context.SaveChangesAsync();
        }
    }
}
