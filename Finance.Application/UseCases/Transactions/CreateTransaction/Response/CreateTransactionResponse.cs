using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.CreateTransaction.Response
{
    public class CreateTransactionResponse : UseCases.Response
    {
        public CreateTransactionResponse(bool success, string? message=null, string? code=null):
            base(success, message, code) 
        {

        }
    }
}
