using Finance.Application.UseCases.Transactions.CreateTransaction;
using Finance.Application.UseCases.Transactions.CreateTransaction.Request;
using Finance.Application.UseCases.Transactions.DeleteTransaction;
using Finance.Application.UseCases.Transactions.DeleteTransaction.Request;
using Finance.Application.UseCases.Transactions.GetTransactionById;
using Finance.Application.UseCases.Transactions.GetTransactionById.Request;
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
        private readonly GetTransactionByIdUseCase _getTransactionById;
        public TransactionController(CreateTransactionUseCase createTransaction, DeleteTransactionUseCase deleteTransaction, GetTransactionByIdUseCase getTransactionById)
        {
            _createTransaction = createTransaction;
            _getTransactionById = getTransactionById;
            _deleteTransaction = deleteTransaction;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> Delete(int id)
        {
            var request = new DeleteTransactionRequest { TransactionId = id };
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
