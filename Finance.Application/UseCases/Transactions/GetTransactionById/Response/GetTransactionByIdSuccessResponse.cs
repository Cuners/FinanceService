using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.GetTransactionById.Response
{
    public class GetTransactionByIdSuccessResponse : GetTransactionByIdResponse
    {
        public GetTransactionByIdSuccessResponse(string message, string code):
            base(true, message, code) 
        {

        }
    }
}
