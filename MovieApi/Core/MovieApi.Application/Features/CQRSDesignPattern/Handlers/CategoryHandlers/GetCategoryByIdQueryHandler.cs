using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Quaries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers {
    public class GetCategoryByIdQueryHandler(MovieContext context) {
        public async Task<GetCategoryByIdQueryResult?> Handle(GetCategoryByIdQuery query) {
            return await context.Categories
                .AsNoTracking()
                .Where(x => x.CategoryId == query.CategoryId)
                .Select(x => new GetCategoryByIdQueryResult {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName
                })
                .FirstOrDefaultAsync();
        }
    }
}
