namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands {
    public class RemoveMovieCommand {
        private int id;

        public RemoveMovieCommand(int id) {
            this.id = id;
        }

        public int MovieId { get; set; }
    }
}
