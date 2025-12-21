
using Finance.Application.UseCases.Accounts.CreateAccount.Response;
using Finance.Application.UseCases.Budgets.СreateBudget.Request;
using Finance.Application.UseCases.Budgets.СreateBudget.Response;
using Finance.Domain;
using Finance.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets.СreateBudget
{
    public class CreateBudgetUseCase
    {
        public readonly IBudgetRepository _budgetRepository;
        public readonly ICategoryRepository _categoryRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<CreateBudgetUseCase> _logger;
        public CreateBudgetUseCase(IBudgetRepository budgetRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ILogger<CreateBudgetUseCase> logger)
        {
            _budgetRepository = budgetRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork=unitOfWork;
            _logger = logger;
        }
        public async Task<CreateBudgetResponse> ExecuteAsync(CreateBudgetRequest request)
        {
            try
            {
                var categories=await _categoryRepository.GetCategoriesById((List<int>)request.Categories);
                var budget = new Domain.Budget
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    LimitAmount = request.LimitAmount,
                    Date=request.Date,
                    Categories = (ICollection<Category>)categories
                };
                await _budgetRepository.CreateBudget(budget);
                await _unitOfWork.SaveChangesAsync();
                return new CreateBudgetSuccessResponse(budget.BudgetId);
            }
            catch (Exception ex) 
            {
                _logger.LogWarning(ex,ex.Message,request.Name);
                return new CreateBudgetErrorResponse("Unable TO CREATE BUDGET at this time", "INVALID_CREATE");
            }
        } 
    }
}
