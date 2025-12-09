using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.UpdateAccount.Response
{
    public abstract class UpdateAccountResponse : UseCases.Response
    {
        protected UpdateAccountResponse(bool success, string? error = null, string? code = null)
            : base(success, error, code)
        {
        }
    }
}
