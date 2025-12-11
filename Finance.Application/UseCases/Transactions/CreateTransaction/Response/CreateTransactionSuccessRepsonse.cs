using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.CreateTransaction.Response
{
    public class CreateTransactionSuccessRepsonse : CreateTransactionResponse
    {
        public CreateTransactionSuccessRepsonse(string message, string code):
            base(true, message, code) 
        {

        }
    }
}
