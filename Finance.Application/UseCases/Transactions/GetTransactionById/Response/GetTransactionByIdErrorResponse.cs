using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.GetTransactionById.Response
{
    public class GetTransactionByIdErrorResponse : GetTransactionByIdResponse
    {
        public GetTransactionByIdErrorResponse(string message, string code):
            base(false, message, code) 
        {

        }
    }
}
