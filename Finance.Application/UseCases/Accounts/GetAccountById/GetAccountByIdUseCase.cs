using Finance.Application.UseCases.Accounts.GetAccountById.Request;
using Finance.Application.UseCases.Accounts.GetAccountById.Response;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response;
using Finance.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountById
{
    public class GetAccountByIdUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAccountByIdUseCase> _logger;
        public GetAccountByIdUseCase(IAccountRepository accountRepository, IUnitOfWork unitOfWork, ILogger<GetAccountByIdUseCase> logger)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<GetAccountByIdResponse> ExecuteAsync(GetAccountByIdRequest request)
        {
            try
            {
                if (request.AccountId <= 0)
                {
                    _logger.LogWarning("GetAccountRequest is null");
                    return new GetAccountByIdErrorResponse("Invalid account id", "INVALID_USER_ID");
                }
                var accounts = _accountRepository.GetAccountByAccountId(request.AccountId);
                if (accounts == null)
                {
                    _logger.LogWarning("GetAccountRequest is null");
                    return new GetAccountByIdErrorResponse("No account found", "ACCOUNT_NOT_FOUND");
                }
                return new GetAccountByIdSuccessResponse(request.AccountId);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return new GetAccountByIdErrorResponse("Unable to get account at this time", "INVALID_GET");
            }
        }
    }
}
