using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountById.Response
{
    public abstract class GetAccountByIdResponse : UseCases.Response
    {
        protected GetAccountByIdResponse(bool success, string? error = null, string? code = null)
            : base(success, error, code)
        {
        }
    }
}
