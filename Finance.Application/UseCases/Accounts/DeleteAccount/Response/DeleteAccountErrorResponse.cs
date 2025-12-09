using Finance.Application.UseCases.Accounts.DeleteAccount.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.DeleteAccount.Response
{
    public class DeleteAccountErrorResponse : DeleteAccountResponse
    {
        public DeleteAccountErrorResponse(string message, string code)
            : base(false, message, code)
        {
        }
    }
}
