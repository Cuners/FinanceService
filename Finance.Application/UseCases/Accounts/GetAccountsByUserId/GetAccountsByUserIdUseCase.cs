using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Request;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response;
using Finance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountsByUserId
{
    public class GetAccountsByUserIdUseCase
    {
        private readonly IAccountRepository _accounts;

        public GetAccountsByUserIdUseCase(IAccountRepository accounts)
        {
            _accounts = accounts;
        }

        public async Task<GetAccountsByUserIdResponse> ExecuteAsync(GetAccountsByUserIdRequest request)
        {
            if (request.UserId <= 0)
                return new GetAccountsByUserIdErrorResponse("Invalid user id", "INVALID_USER_ID");

            var accounts = await _accounts.GetAccountsByUserId(request.UserId);
            if (accounts == null || !accounts.Any())
                return new GetAccountsByUserIdErrorResponse("No accounts found", "ACCOUNTS_NOT_FOUND");

            var result = accounts.Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                Name = a.Name,
                Balance = a.Balance
            }).ToList();

            return new GetAccountsByUserIdSuccessResponse(result);
        }
    }
}
