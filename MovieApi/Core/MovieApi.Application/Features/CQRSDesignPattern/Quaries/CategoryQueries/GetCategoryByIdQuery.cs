namespace MovieApi.Application.Features.CQRSDesignPattern.Quaries.CategoryQueries {
    public class GetCategoryByIdQuery {
        public int CategoryId { get; set; }

        public GetCategoryByIdQuery(int categoryId) {
            CategoryId = categoryId;
        }
    }
}
