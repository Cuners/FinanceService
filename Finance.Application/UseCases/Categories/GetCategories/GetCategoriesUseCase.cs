using Finance.Application.UseCases.Categories.GetCategories.Request;
using Finance.Application.UseCases.Categories.GetCategories.Response;
using Finance.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Categories.GetCategories
{
    public class GetCategoriesUseCase
    {
        private readonly ICategoryRepository _categories;
        private readonly ILogger<GetCategoriesUseCase> _logger;
        public GetCategoriesUseCase(ICategoryRepository categories, ILogger<GetCategoriesUseCase> logger)
        {
            _categories = categories;
            _logger = logger;
        }
        public async Task<GetCategoriesResponse> ExecuteAsync()
        {   
            var categories=await _categories.GetAllCategories();
            if (categories == null)
            {
                return new GetCategoriesErrorResponse("Invalid Categories", "Invalid Category");
            }
            var result=categories.Select(x=>new CategoryDto
            {
                Name=x.Name
            });
            return new GetCategoriesSuccessResponse(result);
        }

    }
}
