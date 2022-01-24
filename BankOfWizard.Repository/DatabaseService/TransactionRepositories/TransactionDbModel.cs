using BankOfWizard.Domain.Transactions;
using System;

namespace BankOfWizard.Repository.DatabaseService.TransactionRepositories
{
    public class TransactionDbModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Info { get; set; }
    }
}
