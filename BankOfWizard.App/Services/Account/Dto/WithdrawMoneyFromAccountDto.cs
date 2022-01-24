using System;

namespace BankOfWizard.App.AccountServices.Dto
{
    public class WithdrawMoneyFromAccountDto
    {
        public Guid AccountId { get; set; }
        public decimal AmountOfMoney { get; set; }

    }
}
