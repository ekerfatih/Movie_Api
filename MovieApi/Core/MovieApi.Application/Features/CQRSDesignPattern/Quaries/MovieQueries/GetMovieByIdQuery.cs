namespace MovieApi.Application.Features.CQRSDesignPattern.Quaries.MovieQueries {
    public class GetMovieByIdQuery {
        private int id;

        public GetMovieByIdQuery(int id) {
            this.id = id;
        }

        public int MovieId { get; set; }
    }
}
