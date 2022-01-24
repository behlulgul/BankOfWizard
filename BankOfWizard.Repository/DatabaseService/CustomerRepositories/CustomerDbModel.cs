
using System;

namespace BankOfWizard.Repository.DatabaseService.CustomerRepositories
{
    public class CustomerDbModel
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
