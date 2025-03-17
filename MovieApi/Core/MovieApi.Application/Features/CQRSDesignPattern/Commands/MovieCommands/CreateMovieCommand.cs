namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands {
    public class CreateMovieCommand {
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
