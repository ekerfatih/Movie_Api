namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries {
    public class GetMovieByIdQuery {

        public GetMovieByIdQuery(int id) {
            MovieId = id;
        }

        public int MovieId { get; set; }
    }
}
