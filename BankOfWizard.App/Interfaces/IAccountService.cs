
using BankOfWizard.App.AccountServices.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> CreateNewAccount(CreateAccountDto accountDto);
        Task WithDrawMoneyFromAccount(WithdrawMoneyFromAccountDto withdrawMoneyDto);
        Task AddMoneyToAccount(AddMoneyToAccountDto addMoneyDto);

        Task<List<BankTransactionDto>> GetAccountTransactionBetweenPeriod(GetAccountAllTransactionsBetweenTimePeriodDto transactionBetweenTimePeriodDto);
        Task<List<BankTransactionDto>> GetAccountAllTransactions(GetAccountAllTransactionsDto getAccountAllTransactionsDto);

    }
}
