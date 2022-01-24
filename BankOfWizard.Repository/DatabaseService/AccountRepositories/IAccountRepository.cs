using BankOfWizard.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface IAccountRepository
    {
        Task<Guid> CreateNewAccount(Account account);
        Task<List<Account>> GetCustomersAllAccount(Guid customerId);
        void UpdateTotalMoneyAmountAccount(Account account);
        Task<Account> GetAccountDetails(Guid id);
        Task<Account> GetAccountDetailsWithCustomerId(Guid accountId,Guid customerId);


    }
}
