using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions.GetTransactionById.Response
{
    public class GetTransactionByIdResponse : UseCases.Response
    {
        public GetTransactionByIdResponse(bool success, string? message=null, string? code=null):
            base(success, message, code)
        {

        }
    }
}
