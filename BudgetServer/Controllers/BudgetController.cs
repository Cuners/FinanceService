using Finance.Application.UseCases.Budgets.DeleteBudget.Request;
using Finance.Application.UseCases.Budgets.GetBudgetById.Request;
using Finance.Application.UseCases.Budgets.GetBudgetsByUserId.Request;
using Finance.Application.UseCases.Budgets.UpdateBudget.Request;
using Finance.Application.UseCases.Budgets.DeleteBudget;
using Finance.Application.UseCases.Budgets.GetBudgetById;
using Finance.Application.UseCases.Budgets.GetBudgetsByUserId;
using Finance.Application.UseCases.Budgets.UpdateBudget;
using Finance.Application.UseCases.Budgets.СreateBudget;
using Finance.Application.UseCases.Budgets.СreateBudget.Request;
using Finance.Application.UseCases.Budgets.СreateBudget.Response;
using Finance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BudgetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly CreateBudgetUseCase _createBudget;
        private readonly GetBudgetsByUserIdUseCase _getBudgets;
        private readonly DeleteBudgetUseCase _deleteBudget;
        private readonly GetBudgetByIdUseCase _getBudgetById;
        private readonly UpdateBudgetUseCase _updateBudget;
        public BudgetController(CreateBudgetUseCase createBudget, GetBudgetsByUserIdUseCase getBudgets, DeleteBudgetUseCase deleteBudget, GetBudgetByIdUseCase getBudgetById, UpdateBudgetUseCase updateBudget)
        {
            _createBudget = createBudget;
            _getBudgets = getBudgets;
            _getBudgetById = getBudgetById;
            _updateBudget = updateBudget;
            _deleteBudget = deleteBudget;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetUserBudgets()
        {
            //if (!Request.Cookies.TryGetValue("UserId", out var userIdString))
            //    return Unauthorized("User is not authenticated.");

            //if (!int.TryParse(userIdString, out var userId))
            //    return Unauthorized("Invalid user ID in cookies.");
            int userId = 1;
            var response = await _getBudgets.ExecuteAsync(
                new GetBudgetsByUserIdRequest { UserId = userId }
            );

            return Ok(response);
        }
        [HttpGet("{budgetid}")]
        public async Task<ActionResult<Budget>> GetBudgetById(int budgetid)
        {
            var request = new GetBudgetByIdRequest { BudgetId = budgetid };
            var response = await _getBudgetById.ExecuteAsync(request);

            return Ok(response);
        }
        [HttpPut("{budgetid}")]
        public async Task<ActionResult<Budget>> Put(UpdateBudgetRequest request)
        {
            var response = await _updateBudget.ExecuteAsync(request);

            return Ok(response);
        }
        [HttpDelete("{budgetid}")]
        public async Task<ActionResult<Budget>> Delete(int budgetid)
        {
            var request = new DeleteBudgetRequest { BudgetId = budgetid };
            var response = await _deleteBudget.ExecuteAsync(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetRequest request)
        {
            var response= await _createBudget.ExecuteAsync(request);
            return Ok(response);
        }
    }
}
