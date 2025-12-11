using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.DeleteTransaction.Response
{
    public class DeleteTransactionResponse : UseCases.Response
    {
        public DeleteTransactionResponse(bool success, string? message=null, string? code=null):
            base(success, message, code) 
        {
            
        }
    }
}
