namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults {
    public class GetCategoryQueryResult {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
