using System;

namespace BankOfWizard.App.AccountServices.Dto
{
    public class AddMoneyToAccountDto
    {
        public Guid AccountId { get; set; }
        public decimal AmountOfMoney { get; set; }

    }
}
