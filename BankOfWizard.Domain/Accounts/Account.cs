using BankOfWizard.Domain.Accounts.Rules;
using BankOfWizard.Domain.BusinessRulesMesages;
using System;


namespace BankOfWizard.Domain.Accounts
{
    public class Account : EntityObject
    {
        public Guid CustomerId { get; set; }
        public string Info { get; set; }
        public decimal TotalMoneyAmount { get; set; }
     
        public static Account Create(Guid id,Guid customerId, string info,decimal initMoney )
        {
            CheckBusinessRule(new AccountIdNoNull(id));
            CheckBusinessRule(new AccountIdNoNull(customerId));
            CheckBusinessRule(new TotalMoneyAmountCannotNegative(initMoney));
            CheckBusinessRule(new DescriptionNoNull(info));

            var account = new Account
            {
                Id = id,
                CustomerId = customerId,
                Info = info,
                TotalMoneyAmount = initMoney
            };

            return account;
        }
       
        public object padlock = new();
        public void IncreaseTotalMoneyAmount(decimal amount)
        {
            lock (padlock)
            {
                TotalMoneyAmount += amount;
            }
        }
        public void DecreaseTotalMoneyAmount(decimal amount)
        {
            lock (padlock)
            {
                TotalMoneyAmount -= amount;
            }

        }

    }
}
