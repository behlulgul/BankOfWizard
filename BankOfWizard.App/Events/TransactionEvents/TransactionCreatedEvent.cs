using BankOfWizard.Domain.Transactions;
using MediatR;
using System;

namespace BankOfWizard.App.TransactionEvents
{
    public class TransactionCreatedEvent : INotification
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public DateTime TranDate { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Info { get; set; }
        public TransactionType TranType { get; set; }

        public TransactionCreatedEvent(Guid id,Guid accountId,DateTime tranDate, TransactionType tranType,decimal totalMoneyAmount,decimal amountOfMoney)
        {
            Id = id;
            AccountId = accountId;
            TranDate = tranDate;
            Info = "";
            TranType = tranType;
            TotalMoneyAmount = totalMoneyAmount;
            AmountOfMoney = amountOfMoney;
        }
    }
}
