using Finance.Application.UseCases.Accounts.CreateAccount;
using Finance.Application.UseCases.Accounts.GetAccountsByUserId;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace Finance.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateAccountUseCase>();
            //services.AddScoped<GetAccountsUseCase>();
            services.AddScoped<GetAccountsByUserIdUseCase>();
            //services.AddScoped<DeleteAccountUseCase>();
            //services.AddScoped<UpdateAccountUseCase>();

            return services;
        }
    }
}
