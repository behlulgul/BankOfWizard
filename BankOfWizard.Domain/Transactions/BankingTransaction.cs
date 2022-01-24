using BankOfWizard.Domain.BusinessRulesMesages;
using System;

namespace BankOfWizard.Domain.Transactions
{
    public class BankingTransaction : EntityObject
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }

        public BankingTransaction(Guid accountId, decimal amount, decimal totalMoneyAmount, TransactionType type, DateTime date, string info)
        {
            AccountId = accountId;
            Amount = amount;
            TotalMoneyAmount = totalMoneyAmount;
            Date = date;
            Type = type;
            Info = info;

        }
    }
}
