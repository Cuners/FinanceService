using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountsByUserId.Response
{
    public class GetAccountsByUserIdErrorResponse : GetAccountsByUserIdResponse
    {
        public GetAccountsByUserIdErrorResponse(string message, string code)
            : base(false, message, code)
        {
        }
    }
}
