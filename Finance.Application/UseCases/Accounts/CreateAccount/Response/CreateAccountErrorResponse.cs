using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.CreateAccount.Response
{
    public class CreateAccountErrorResponse : CreateAccountResponse
    {
        public CreateAccountErrorResponse(string message, string code)
            : base(false, message, code)
        {
        }
    }
}
