using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Categories.GetCategories.Response
{
    public class GetCategoriesResponse : UseCases.Response
    {
        public GetCategoriesResponse(bool success, string? message=null, string? code=null):
            base(success, message, code)
        {

        }
    }
}
