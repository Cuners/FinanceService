using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.GetBudgetsByUserId.Response
{
    public class GetBudgetsByUserIdErrorResponse : GetBudgetsByUserIdResponse
    {
        public GetBudgetsByUserIdErrorResponse(string message, string code) :
        base(false, message, code)
        {

        }
    }
}
