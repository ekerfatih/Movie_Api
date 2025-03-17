using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Quaries.CategoryQueries;

namespace MovieApi.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler) {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }



        [HttpGet]
        public async Task<IActionResult> GetCategories() {
            var categories = await _getCategoryQueryHandler.Handle();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id) {
            var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return category != null ? Ok(category) : NotFound($"Category with ID {id} not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command) {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Category Created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command) {
            if (id != command.CategoryId) return BadRequest("ID mismatch.");
            var updated = await _updateCategoryCommandHandler.Handle(command);
            return updated ? Ok("Category updated successfully.") : NotFound($"Category with ID {id} not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) {
            var deleted = await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return deleted ? Ok("Category deleted successfully.") : NotFound($"Category with ID {id} not found.");
        }
    }
}
