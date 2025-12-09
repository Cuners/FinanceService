
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.UpdateAccount.Response
{
    public class UpdateAccountErrorResponse : UpdateAccountResponse
    {
        public UpdateAccountErrorResponse(string message, string code)
            : base(false, message, code)
        {
        }
    }
}
