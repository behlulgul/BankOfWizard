using System;

namespace BankOfWizard.App.AccountServices.Dto
{
    public class GetAccountAllTransactionsBetweenTimePeriodDto
    {
        public Guid AccountId { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
    }
}
