using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.CreateAccount.Response
{
    public abstract class CreateAccountResponse : UseCases.Response
    {
        protected CreateAccountResponse(bool success, string? error = null, string? code = null)
            : base(success, error, code)
        {
        }
    }
}
