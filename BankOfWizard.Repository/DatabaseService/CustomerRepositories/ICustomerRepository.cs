
using BankOfWizard.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Guid> CreateNewCustomer(Customer customer);
        Task<Customer> GetCustomerById(Guid id);
        bool GetCustomerByCustomerNumber(string customerNumber);
       
    }
}
