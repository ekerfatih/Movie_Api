namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands {
    public class RemoveMovieCommand {

        public RemoveMovieCommand(int id) {
            MovieId = id;
        }

        public int MovieId { get; set; }
    }
}
