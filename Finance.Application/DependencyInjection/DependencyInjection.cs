using Finance.Application.UseCases.Accounts.CreateAccount;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId;
using Finance.Application.UseCases.Accounts.DeleteAccount;
using Finance.Application.UseCases.Accounts.GetAccountById;
using Finance.Application.UseCases.Accounts.UpdateAccount;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Finance.Application.UseCases.Budgets.СreateBudget;
namespace Finance.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateAccountUseCase>();
            services.AddScoped<GetAccountByIdUseCase>();
            services.AddScoped<GetAccountsByUserIdUseCase>();
            services.AddScoped<DeleteAccountUseCase>();
            services.AddScoped<UpdateAccountUseCase>();
            services.AddScoped<CreateBudgetUseCase>();
            return services;
        }
    }
}
