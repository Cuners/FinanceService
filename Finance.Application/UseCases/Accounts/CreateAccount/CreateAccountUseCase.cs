using Finance.Application.UseCases.Accounts.CreateAccount.Request;
using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using Finance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountUseCase
    {
        private readonly IAccountRepository _accounts;

        public CreateAccountUseCase(IAccountRepository accounts)
        {
            _accounts = accounts;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return new CreateAccountErrorResponse("Account name is empty", "ACC_EMPTY_NAME");
            var account = new Domain.Account
            {
                UserId = request.UserId,
                Name = request.Name,
                Balance = request.Balance
            };
            await _accounts.CreateAccount(account);
            await _accounts.SaveChangesAsync();

            return new CreateAccountSuccessResponse(account.AccountId);
        }
    }
}
