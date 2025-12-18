using Finance.Application.UseCases.Transactions;
using Finance.Application.UseCases.Transactions.GetTransactionsByAccountId;
using Finance.Application.UseCases.Transactions.GetTransactionsByAccountId.Request;
using Finance.Application.UseCases.Transactions.GetTransactionsByAccountId.Response;
using Finance.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.GetTransactionsByAccountId
{
    public class GetTransactionsByAccountIdUseCase
    {
        private readonly ITransactionRepository _Transaction;
        private readonly ILogger<GetTransactionsByAccountIdUseCase> _logger;
        public GetTransactionsByAccountIdUseCase(ITransactionRepository Transaction, ILogger<GetTransactionsByAccountIdUseCase> logger)
        {
            _Transaction = Transaction;
            _logger = logger;
        }
        public async Task<GetTransactionsByAccountIdResponse> ExecuteAsync(GetTransactionsByAccountIdRequest request)
        {
            try
            {
                if (request == null)
                {
                    _logger.LogWarning("GetTransactionRequest is null");
                    return new GetTransactionsByAccountIdErrorResponse("Invalid Transaction", "INVALID_Transaction");
                }
                var Transactions = await _Transaction.GetTransactionsByAccountId(request.AccountId);
                var result = Transactions.Select(x => new TransactionDto
                {
                    AccountId = x.AccountId,
                    CategoryId = x.CategoryId,
                    Amount = x.Amount,
                    CategoryName=x.Category.Name,
                    AccountName=x.Account.Name,
                    Date = x.Date,
                    Note = x.Note
                }).ToList();
                return new GetTransactionsByAccountIdSuccessResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return new GetTransactionsByAccountIdErrorResponse("Unable to get Transactions at this time", "INVALID_UPDATE");
            }
        }
    }
}
