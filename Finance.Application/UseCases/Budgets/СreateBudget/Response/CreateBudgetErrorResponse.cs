using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.СreateBudget.Response
{
    public class CreateBudgetErrorResponse : CreateBudgetResponse
    {
        public CreateBudgetErrorResponse(string message,string code):
            base(false, message, code)
        {

        }
    }
}
