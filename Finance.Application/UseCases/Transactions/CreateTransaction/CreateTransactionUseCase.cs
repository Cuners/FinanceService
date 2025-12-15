using Finance.Application.UseCases.Transactions.CreateTransaction.Request;
using Finance.Application.UseCases.Transactions.CreateTransaction.Response;
using Finance.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.CreateTransaction
{
    public class CreateTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateTransactionUseCase> _logger;

        public CreateTransactionUseCase(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateTransactionUseCase> logger)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CreateTransactionResponse> ExecuteAsync(CreateTransactionRequest request)
        {
            try
            {
                if (request.Amount == 0)
                {
                    return new CreateTransactionErrorResponse("Amount cannot be zero", "INVALID_AMOUNT");
                }
                var account = await _accountRepository.GetAccountByAccountId(request.AccountId);
                if (account == null)
                {
                    return new CreateTransactionErrorResponse("Account not found or access denied", "ACCOUNT_NOT_FOUND");
                }
                var category = await _categoryRepository.GetCategoryById(request.CategoryId);
                if (category == null)
                {
                    return new CreateTransactionErrorResponse("Category not found", "CATEGORY_NOT_FOUND");
                }

                var transaction = new Domain.Transaction
                {
                    AccountId = request.AccountId,
                    CategoryId = request.CategoryId,
                    Amount = request.Amount,
                    Date = request.Date,
                    Note = request.Note
                };

                await _transactionRepository.CreateTransaction(transaction);
                await _unitOfWork.SaveChangesAsync();

                return new CreateTransactionSuccessRepsonse(transaction.TransactionId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error creating transaction for user");
                return new CreateTransactionErrorResponse("Failed to create transaction", "INTERNAL_ERROR");
            }
        }
    }
}
