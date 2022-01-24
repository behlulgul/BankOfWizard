using BankOfWizard.Domain.Accounts.Rules;
using BankOfWizard.Domain.Customers.Rules;
using BankOfWizard.Domain.BusinessRulesMesages;
using System;
using System.Collections.Generic;

namespace BankOfWizard.Domain.Customers
{
    public class Customer : EntityObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public List<CustomerAccount> Accounts { get; set; }
    

        public static Customer Create(Guid id,string customerNumber, string name, string surname, string phoneNumber, string city, string county)
        {
            CheckBusinessRule(new AccountIdNoNull(id));
            CheckBusinessRule(new NameNoNull(name));
            CheckBusinessRule(new SurnameNoNull(surname));
            CheckBusinessRule(new CustomerNumberLengthIs4(customerNumber));
            CheckBusinessRule(new PhoneNumberNoNull(phoneNumber));
            CheckBusinessRule(new CityNoNull(city));
            CheckBusinessRule(new CountyNoNull(county));

            var customer = new Customer
            {
                Id = id,
                Name = name,
                Surname = surname,
                CustomerNumber = customerNumber,
                PhoneNumber = phoneNumber,
                City = city,
                County = county,

            };

            return customer;
        }
    }
}
