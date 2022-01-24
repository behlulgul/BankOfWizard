using AutoMapper;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Customers;
using BankOfWizard.Repository.DatabaseService.CustomerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfWizard.Repository.DatabaseService
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDbContext context,
                                 IMapper mapper)
        {
      
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateNewCustomer(Customer customer)
        {
            var dbModel = _mapper.Map<CustomerDbModel>(customer);
            dbModel.CreatedDate = DateTime.Now;

            await _context.Customer.AddAsync(dbModel);

            return dbModel.Id;

        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var dbModel = await _context.Customer.FindAsync(id); 

            return _mapper.Map<Customer>(dbModel);
        }

        public bool GetCustomerByCustomerNumber(string customerNumber)
        {
            return _context.Customer.Any(c => c.CustomerNumber == customerNumber);
        }



    }
}
