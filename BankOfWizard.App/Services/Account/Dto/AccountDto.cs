using BankOfWizard.Domain.Accounts;
using System;


namespace BankOfWizard.App.AccountServices.Dto
{
    public class AccountDto
    {
        public Guid CustomerId { get; set; }
        public string Info { get; set; }
        public decimal TotalMoneyAmount { get; set; }
    }
}
