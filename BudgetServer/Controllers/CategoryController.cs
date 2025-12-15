
using Finance.Application.UseCases.Categories.GetCategories;
using Finance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BudgetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly GetCategoriesUseCase _getCategories;
        public CategoryController(GetCategoriesUseCase getCategories)
        {
            _getCategories = getCategories;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetUserCategories()
        {
            //if (!Request.Cookies.TryGetValue("UserId", out var userIdString))
            //    return Unauthorized("User is not authenticated.");

            //if (!int.TryParse(userIdString, out var userId))
            //    return Unauthorized("Invalid user ID in cookies.");
            var response = await _getCategories.ExecuteAsync();
            return Ok(response);
        }
    }
}
