using System;


namespace BankOfWizard.App.AccountServices.Dto
{
    public class CreateAccountDto
    {
        public Guid CustomerId { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public string Info { get; set; }
    }
}
