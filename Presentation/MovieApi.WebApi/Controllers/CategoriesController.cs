using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class CategoriesController : ControllerBase
    {

        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

		public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
		{
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var value = await _getCategoryQueryHandler.Handle();

			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _createCategoryCommandHandler.Handle(command);

			return Ok("Kategori ekleme işlemi başarılı");
		}

			

	}
}
