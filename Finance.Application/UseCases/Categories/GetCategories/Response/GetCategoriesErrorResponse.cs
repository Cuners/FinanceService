using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Categories.GetCategories.Response
{
    public class GetCategoriesErrorResponse : GetCategoriesResponse
    {
        public GetCategoriesErrorResponse(string message,string code) :
            base(false)
        {

        }

    }
}
