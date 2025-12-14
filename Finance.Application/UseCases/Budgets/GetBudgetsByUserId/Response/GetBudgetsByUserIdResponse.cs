using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.GetBudgetsByUserId.Response
{
    public class GetBudgetsByUserIdResponse : UseCases.Response
    {
        public GetBudgetsByUserIdResponse(bool success, string? message=null, string? code=null): 
            base(success, message,code) 
        {

        }
    }
}
