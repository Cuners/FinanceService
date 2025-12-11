using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.СreateBudget.Response
{
    public abstract class CreateBudgetResponse : UseCases.Response
    {
        public CreateBudgetResponse(bool success, string? error=null, string? code=null):
            base(success, error, code) 
        { 

        }
    }
}
