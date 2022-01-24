
using BankOfWizard.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface ITransactionRepository
    {
       Task AddMoneyTransaction(BankingTransaction entity);
       Task<List<BankingTransaction>> GetAccountAllTranscations(Guid id);
       Task<List<BankingTransaction>> GetAccountTranscationsBetweenTime(Guid id, DateTime startedDate, DateTime endedDate);
    }
}
