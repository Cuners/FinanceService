using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response
{
    public abstract class GetAccountsByUserIdResponse : UseCases.Response
    {
        protected GetAccountsByUserIdResponse(bool success, string? error = null, string? code = null)
            : base(success, error, code)
        {
        }
    }
}
