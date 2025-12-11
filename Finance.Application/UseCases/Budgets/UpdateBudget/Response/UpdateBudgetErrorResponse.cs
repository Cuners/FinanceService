using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.UpdateBudget.Response
{
    public class UpdateBudgetErrorResponse: UpdateBudgetResponse
    {
        public UpdateBudgetErrorResponse(string message,string code):
            base(false, message, code)
        {

        }
    }
}
