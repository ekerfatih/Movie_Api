namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults {
    public class GetMovieByIdQueryResult {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public required string CoverImage { get; set; }
        public decimal Rating { get; set; }
        public required string Description { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
