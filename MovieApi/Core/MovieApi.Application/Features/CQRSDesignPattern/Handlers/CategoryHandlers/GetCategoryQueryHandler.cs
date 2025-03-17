using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers {
    public class GetCategoryQueryHandler(MovieContext context) {
        public async Task<List<GetCategoryQueryResult>> Handle() {
            return await context.Categories
                .AsNoTracking()
                .Select(x => new GetCategoryQueryResult {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName
                })
                .ToListAsync();
        }
    }
}
