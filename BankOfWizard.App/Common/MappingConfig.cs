using AutoMapper;
using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.Domain.Accounts;
using BankOfWizard.Domain.Customers;
using BankOfWizard.Domain.Transactions;
using BankOfWizard.Repository.DatabaseService.AccountRepositories;
using BankOfWizard.Repository.DatabaseService.CustomerRepositories;
using BankOfWizard.Repository.DatabaseService.TransactionRepositories;

namespace BankOfWizard.App.Common
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Customer, CustomerDbModel>().ReverseMap();
            CreateMap<Account, AccountDbModel>().ReverseMap();
            CreateMap<BankingTransaction, TransactionDbModel>().ReverseMap();

            CreateMap<BankingTransaction, BankTransactionDto>();
            CreateMap<BankingTransaction, BankTransactionDto>();
            CreateMap<BankingTransaction, BankTransactionDto>();

        }

    }
}
