using Finance.Application.UseCases.Accounts.CreateAccount;
using Finance.Application.UseCases.Accounts.CreateAccount.Request;
using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Request;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response;
using Finance.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly CreateAccountUseCase _createAccount;
        private readonly GetAccountsByUserIdUseCase _getAccounts;
        public AccountsController(CreateAccountUseCase createAccount, GetAccountsByUserIdUseCase getAccounts)
        {
            _createAccount = createAccount;
            _getAccounts = getAccounts;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetUserAccounts()
        {
            //if (!Request.Cookies.TryGetValue("UserId", out var userIdString))
            //    return Unauthorized("User is not authenticated.");

            //if (!int.TryParse(userIdString, out var userId))
            //    return Unauthorized("Invalid user ID in cookies.");
            int userId = 1;
            var response = await _getAccounts.ExecuteAsync(
                new GetAccountsByUserIdRequest { UserId = userId }
            );

            if (!response.Success)
            {
                return BadRequest(new
                {
                    error = response.ErrorMessage,
                    code = response.ErrorCode
                });
            }
            var success = (GetAccountsByUserIdSuccessResponse)response;

            return Ok(success.Accounts);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountRequest request)
        {
            var response = await _createAccount.ExecuteAsync(request);

            if (!response.Success)
            {
                return BadRequest(new
                {
                    error = response.ErrorMessage,
                    code = response.ErrorCode
                });
            }

            var success = (CreateAccountSuccessResponse)response;

            return Ok(new { accountId = success.AccountId });
        }
    }
}
