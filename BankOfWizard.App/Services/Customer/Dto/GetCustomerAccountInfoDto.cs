using System;

namespace BankOfWizard.App.CustomerServices.Dto
{
    public class GetCustomerAccountInfoDto
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
    }
}
