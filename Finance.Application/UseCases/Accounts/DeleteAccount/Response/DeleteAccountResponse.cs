using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.DeleteAccount.Response
{
    public abstract class DeleteAccountResponse : UseCases.Response
    {
        protected DeleteAccountResponse(bool success, string? error = null, string? code = null)
            : base(success, error, code)
        {
        }
    }
}
