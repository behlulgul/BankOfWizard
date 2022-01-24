using AutoMapper;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Transactions;
using BankOfWizard.Repository.DatabaseService.TransactionRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfWizard.Repository.DatabaseService
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TransactionRepository(ApplicationDbContext context,
                                     IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddMoneyTransaction(BankingTransaction entity)
        {
            var result = _mapper.Map<TransactionDbModel>(entity);
            await _context.TransactionTable.AddAsync(result);
        }

        public async Task<List<BankingTransaction>> GetAccountAllTranscations(Guid accountId)
        {

            var result = await _context.TransactionTable.Where(t=>t.AccountId==accountId).ToListAsync();

            return _mapper.Map<List<BankingTransaction>>(result);
        }

        public async Task<List<BankingTransaction>> GetAccountTranscationsBetweenTime(Guid id, DateTime startedDate, DateTime endedDate)
        {
            var result = await _context.TransactionTable.Where(t => t.AccountId == id && t.Date >= startedDate && t.Date <= endedDate).ToListAsync();

            return _mapper.Map<List<BankingTransaction>>(result);
        }

    }
}
