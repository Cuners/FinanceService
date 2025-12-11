using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.CreateTransaction.Response
{
    public class CreateTransactionErrorResponse : CreateTransactionResponse
    {
        public CreateTransactionErrorResponse(string message, string error):
            base(false, message, error)
        {

        }
    }
}
