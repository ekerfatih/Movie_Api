using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase {
        private readonly CreateMovieCommandHandler _createMovieHandler;
        private readonly RemoveMovieCommandHandler _removeMovieHandler;
        private readonly UpdateMovieCommandHandler _updateMovieHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;

        public MovieController(
            CreateMovieCommandHandler createMovieHandler,
            RemoveMovieCommandHandler removeMovieHandler,
            UpdateMovieCommandHandler updateMovieHandler,
            GetMovieByIdQueryHandler getMovieByIdHandler,
            GetMovieQueryHandler getMovieQueryHandler
        ) {
            _createMovieHandler = createMovieHandler;
            _removeMovieHandler = removeMovieHandler;
            _updateMovieHandler = updateMovieHandler;
            _getMovieByIdHandler = getMovieByIdHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies() {
            var movies = await _getMovieQueryHandler.Handle();
            return Ok(movies);
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id) {
            var movie = await _getMovieByIdHandler.Handle(new GetMovieByIdQuery(id));
            return movie != null ? Ok(movie) : NotFound(new { message = $"Movie with ID {id} not found." });
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command) {
            await _createMovieHandler.Handle(command);
            return Ok("Movie Created successfully");
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieCommand command) {
            if (id != command.MovieId) return BadRequest(new { message = "ID mismatch." });

            var updated = await _updateMovieHandler.Handle(command);
            return updated ? Ok(new { message = "Movie updated successfully." })
                           : NotFound(new { message = $"Movie with ID {id} not found." });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id) {
            var deleted = await _removeMovieHandler.Handle(new RemoveMovieCommand(id));
            return deleted ? Ok(new { message = "Movie deleted successfully." })
                           : NotFound(new { message = $"Movie with ID {id} not found." });
        }
    }
}
