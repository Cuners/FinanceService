using Finance.Application.UseCases.Accounts.DeleteAccount.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.DeleteBudget.Response
{
    public class DeleteBudgetErrorResponse : DeleteBudgetResponse
    {
        public DeleteBudgetErrorResponse(string message,string code):
            base(false, message, code)
        {

        }
    }
}
