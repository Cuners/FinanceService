
using Finance.Application.UseCases.Transactions.CreateTransaction;
using Finance.Application.UseCases.Transactions.CreateTransaction.Request;
using Finance.Application.UseCases.Transactions.DeleteTransaction;
using Finance.Application.UseCases.Transactions.DeleteTransaction.Request;
using Finance.Application.UseCases.Transactions.GetTransactionById;
using Finance.Application.UseCases.Transactions.GetTransactionById.Request;
using Finance.Application.UseCases.Transactions.GetTransactionsByAccountId;
using Finance.Application.UseCases.Transactions.GetTransactionsByAccountId.Request;
using Finance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace TransactionServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly CreateTransactionUseCase _createTransaction;
       // private readonly GetTransactionsByUserIdUseCase _getTransactions;
        private readonly DeleteTransactionUseCase _deleteTransaction;
        private readonly GetTransactionsByAccountIdUseCase _getTransactionByAccountId;
        private readonly GetTransactionByIdUseCase _getTransactionById;
        public TransactionController(CreateTransactionUseCase createTransaction, DeleteTransactionUseCase deleteTransaction, GetTransactionsByAccountIdUseCase getTransactionByAccountId, GetTransactionByIdUseCase getTransactionById)
        {
            _createTransaction = createTransaction;
            _getTransactionByAccountId = getTransactionByAccountId;
            _deleteTransaction = deleteTransaction;
            _getTransactionById = getTransactionById;
        }
        [HttpGet("/api/Accounts/{accountId}/Transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionByAccountId(int accountId)
        {
            var request = new GetTransactionsByAccountIdRequest { AccountId = accountId };
            var response = await _getTransactionByAccountId.ExecuteAsync(request);

            return Ok(response);
        }
        [HttpGet("{transactionid}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int transactionid)
        {
            var request = new GetTransactionByIdRequest { TransactionId = transactionid };
            var response = await _getTransactionById.ExecuteAsync(request);
            return Ok(response);
        }
        [HttpDelete("{transactionid}")]
        public async Task<ActionResult<Transaction>> Delete(int transactionid)
        {
            var request = new DeleteTransactionRequest { TransactionId = transactionid };
            var response = await _deleteTransaction.ExecuteAsync(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionRequest request)
        {
            var response = await _createTransaction.ExecuteAsync(request);
            return Ok(response);
        }
    }
}
