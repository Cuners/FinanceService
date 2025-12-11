using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.GetBudgetById.Response
{
    public abstract class GetBudgetByIdResponse : UseCases.Response
    {
        public GetBudgetByIdResponse(bool success,string? error=null,string? code=null):
            base(success, error, code)
        {

        }
    }
}
