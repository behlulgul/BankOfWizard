
using System;

namespace BankOfWizard.Repository.DatabaseService.AccountRepositories
{
    public class AccountDbModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Info { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public AccountDbModel(Guid customerId, string info, decimal totalMoneyAmount)
        {
            CustomerId = customerId;
            Info = info;
            TotalMoneyAmount = totalMoneyAmount;

        }
    }
}
