using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.GetBudgetById.Response
{
    public class GetBudgetByIdSuccessResponse : GetBudgetByIdResponse
    {
        public int BudgetId { get; set; }
        public GetBudgetByIdSuccessResponse(int id)
        {
            BudgetId = id;
        }
    }
}
