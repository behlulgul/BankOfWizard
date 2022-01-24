using AutoMapper;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Accounts;
using BankOfWizard.Repository.DatabaseService.AccountRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfWizard.Repository.DatabaseService
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AccountRepository(ApplicationDbContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateNewAccount(Account account)
        {
            var dbModel = _mapper.Map<AccountDbModel>(account);
            dbModel.CreatedDate = DateTime.Now;

            await _context.AccountTable.AddAsync(dbModel);

            return dbModel.Id;
        }

        public async Task<Account> GetAccountDetails(Guid id)
        {
            var accountDbTable =await _context.AccountTable.FindAsync(id);

            return  _mapper.Map<Account>(accountDbTable); 
        }

        public async Task<Account> GetAccountDetailsWithCustomerId(Guid accountId, Guid customerId)
        {
            var accountDbTable = await _context.AccountTable.Where(w => w.Id == accountId && w.CustomerId == customerId).FirstOrDefaultAsync();

            return _mapper.Map<Account>(accountDbTable);
        }

        public void UpdateTotalMoneyAmountAccount(Account account)
        {
                      
            var accountInfo =  _context.AccountTable.FirstOrDefault(x=>x.Id== account.Id);
            accountInfo.TotalMoneyAmount = account.TotalMoneyAmount;
            accountInfo.CreatedDate = DateTime.Now;
        }

        public async Task<List<Account>> GetCustomersAllAccount(Guid customerId)
        {
            var dbModelList = await _context.AccountTable.Where(a => a.CustomerId == customerId).ToListAsync(); 

            return _mapper.Map<List<Account>>(dbModelList);
        }


     

   

    }
}
