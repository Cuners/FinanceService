using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.DeleteTransaction.Response
{
    public class DeleteTransactionErrorResponse : DeleteTransactionResponse
    {
        public DeleteTransactionErrorResponse(string message,string code): base
            (false, message, code)
        {

        }
    }
}
