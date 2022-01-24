
using BankOfWizard.Domain.Transactions;
using System;

namespace BankOfWizard.App.AccountServices.Dto
{
    public class BankTransactionDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Info { get; set; }
    }
}
