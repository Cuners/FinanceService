using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using Finance.Application.UseCases.Budgets.СreateBudget;
using Finance.Application.UseCases.Budgets.СreateBudget.Request;
using Finance.Application.UseCases.Budgets.СreateBudget.Response;
using Microsoft.AspNetCore.Mvc;

namespace BudgetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly CreateBudgetUseCase _createBudget;
        public BudgetController(CreateBudgetUseCase createBudget)
        {
            _createBudget = createBudget;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetRequest request)
        {
            var response= await _createBudget.ExecuteAsync(request);
            if (!response.Success)
            {
                return BadRequest(new
                {
                    error = response.ErrorMessage,
                    code = response.ErrorCode
                });
            }

            var success = (CreateBudgetSuccessResponse)response;
            return Ok(new {});
        }
    }
}
