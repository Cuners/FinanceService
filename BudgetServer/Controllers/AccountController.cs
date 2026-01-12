using Finance.Application.UseCases.Accounts.CreateAccount;
using Finance.Application.UseCases.Accounts.CreateAccount.Request;
using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using Finance.Application.UseCases.Accounts.DeleteAccount;
using Finance.Application.UseCases.Accounts.DeleteAccount.Request;
using Finance.Application.UseCases.Accounts.DeleteAccount.Response;
using Finance.Application.UseCases.Accounts.GetAccountById;
using Finance.Application.UseCases.Accounts.GetAccountById.Request;
using Finance.Application.UseCases.Accounts.GetAccountById.Response;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Request;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response;
using Finance.Application.UseCases.Accounts.UpdateAccount;
using Finance.Application.UseCases.Accounts.UpdateAccount.Request;
using Finance.Application.UseCases.Accounts.UpdateAccount.Response;
using Finance.Application.Validators;
using Finance.Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CreateAccountUseCase _createAccount;
        private readonly GetAccountsByUserIdUseCase _getAccounts;
        private readonly DeleteAccountUseCase _deleteAccount;
        private readonly GetAccountByIdUseCase _getAccountById;
        private readonly UpdateAccountUseCase _updateAccount;
        public AccountController(CreateAccountUseCase createAccount, 
                                GetAccountsByUserIdUseCase getAccounts, 
                                DeleteAccountUseCase deleteAccount, 
                                GetAccountByIdUseCase getAccountById, 
                                UpdateAccountUseCase updateAccount)
        {
            _createAccount = createAccount;
            _getAccounts = getAccounts;
            _getAccountById = getAccountById;
            _updateAccount = updateAccount;
            _deleteAccount = deleteAccount;
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

            return Ok(response);
        }
        [HttpGet("{accountid}")]
        public async Task<ActionResult<Account>> GetAccountById(int accountid)
        {
            
            var request = new GetAccountByIdRequest { AccountId = accountid };
            var response = await _getAccountById.ExecuteAsync(request);

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountRequest request)
        {
            var response = await _createAccount.ExecuteAsync(request);
            return Ok(response);
        }
        [HttpPut("{accountid}")]
        public async Task<ActionResult<Account>> Put(UpdateAccountRequest request)
        {
            var response = await _updateAccount.ExecuteAsync(request);

            return Ok(response);
        }
        [HttpDelete("{accountid}")]
        public async Task<ActionResult<Account>> Delete(int accountid)
        {
            var request = new DeleteAccountRequest{ AccountId = accountid };
            var response = await _deleteAccount.ExecuteAsync(request);
            return Ok(response);
        }
    }
}
