using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.UpdateBudget.Response
{
    public class UpdateBudgetResponse : UseCases.Response
    {
        public UpdateBudgetResponse(bool success, string? message = null, string? code=null):
            base(success, message, code)
        {

        }
    }
}
