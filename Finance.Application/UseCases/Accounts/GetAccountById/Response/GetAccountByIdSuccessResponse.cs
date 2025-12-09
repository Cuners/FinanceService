using Finance.Application.UseCases.Accounts.GetAccountById.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts.GetAccountById.Response
{
    public class GetAccountByIdSuccessResponse : GetAccountByIdResponse
    {
        public int AccountId { get; }

        public GetAccountByIdSuccessResponse(int id)
            : base(true)
        {
            AccountId = id;
        }
    }
}
