using BankOfWizard.Identity.Jwt;
using BankOfWizard.App.AccountServices;
using BankOfWizard.App.CustomerServices;
using BankOfWizard.App.Interfaces;
using BankOfWizard.App.TransactionEvents;
using BankOfWizard.Repository.DatabaseService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BankOfWizard.Configs

{
    public static class ServiceConfig
    {
        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(TransactionCreatedEvent).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AccountRepository).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CustomerRepository).GetTypeInfo().Assembly);

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<UserManager<IdentityUser>>();
            services.AddScoped<IdentityRole, IdentityRole>();
        }
    }
}
