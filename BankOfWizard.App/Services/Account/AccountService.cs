using AutoMapper;
using BankOfWizard.App.Common;
using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.App.Interfaces;
using BankOfWizard.App.TransactionEvents;
using BankOfWizard.Domain.Accounts;
using BankOfWizard.Domain.BusinessRulesMesages;
using BankOfWizard.Domain.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfWizard.App.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, 
                              IMediator mediator,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }

    

        [Logging]
        public async Task<Guid> CreateNewAccount(CreateAccountDto accountDto)
        {
                       
            if (accountDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var customer = await _unitOfWork.CustomerRepository.GetCustomerById(accountDto.CustomerId);

            if (customer == null)
                throw new Exception(ErrorMessages.CustomerNotFound);

            var account = Account.Create(Guid.NewGuid(), accountDto.CustomerId, accountDto.Info, accountDto.TotalMoneyAmount);

            var accountId = await _unitOfWork.AccountRepository.CreateNewAccount(account);

            if (accountId == Guid.Empty)
                throw new Exception(ErrorMessages.AccountCouldNotCreated);

            _unitOfWork.Complete();
        
            return accountId;

        }

        [Logging]
        public async Task AddMoneyToAccount(AddMoneyToAccountDto addMoneyDto)
        {
            if (addMoneyDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var account = await _unitOfWork.AccountRepository.GetAccountDetails(addMoneyDto.AccountId);

            if (account == null)
                throw new Exception(ErrorMessages.AccountNotFound);

            if (addMoneyDto.AmountOfMoney <= 0)
                throw new Exception(ErrorMessages.AmountOfMoneyCannotNegativeOrZero);

            account.IncreaseTotalMoneyAmount(addMoneyDto.AmountOfMoney);
          
            _unitOfWork.AccountRepository.UpdateTotalMoneyAmountAccount(account);
            _unitOfWork.Complete();

             await _mediator.Publish(new TransactionCreatedEvent(new Guid(),account.Id,new DateTime(), TransactionType.AddMoneyToAccount,account.TotalMoneyAmount,addMoneyDto.AmountOfMoney),new CancellationToken());

        }

        [Logging]
        public async Task WithDrawMoneyFromAccount(WithdrawMoneyFromAccountDto withdrawMoneyDto)
        {
            if (withdrawMoneyDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var account =await  _unitOfWork.AccountRepository.GetAccountDetails(withdrawMoneyDto.AccountId);

            if (account == null)
                throw new Exception(ErrorMessages.AccountNotFound);

            if (withdrawMoneyDto.AmountOfMoney > account.TotalMoneyAmount )
                throw new Exception(ErrorMessages.NotEnoughTotalMoneyAmount);


            if (withdrawMoneyDto.AmountOfMoney <= 0 )
                throw new Exception(ErrorMessages.AmountOfMoneyCannotNegativeOrZero);

            account.DecreaseTotalMoneyAmount(withdrawMoneyDto.AmountOfMoney);
           
            _unitOfWork.AccountRepository.UpdateTotalMoneyAmountAccount(account);
            _unitOfWork.Complete();

            await _mediator.Publish(new TransactionCreatedEvent(new Guid(), account.Id, new DateTime(), TransactionType.WithdrawMoneyFromAccount, account.TotalMoneyAmount, withdrawMoneyDto.AmountOfMoney), new CancellationToken());
        }

        [Logging]
        public async Task<List<BankTransactionDto>> GetAccountAllTransactions(GetAccountAllTransactionsDto getAccountTransactionDto)
        {
            if (getAccountTransactionDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var transactions = await _unitOfWork.TransactionRepository.GetAccountAllTranscations(getAccountTransactionDto.AccountId);

            if (transactions == null)
                throw new Exception(ErrorMessages.NullParemeter);

            if (transactions.Count == 0)
                throw new Exception(ErrorMessages.ZeroCount);

            var transactionsDto = _mapper.Map<List<BankTransactionDto>>(transactions);

            return transactionsDto;
        }

        [Logging]
        public async Task<List<BankTransactionDto>> GetAccountTransactionBetweenPeriod(GetAccountAllTransactionsBetweenTimePeriodDto transactionWithTimePeriodDto)
        {
            if (transactionWithTimePeriodDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var transactions = await _unitOfWork.TransactionRepository.GetAccountTranscationsBetweenTime(
                transactionWithTimePeriodDto.AccountId,
                transactionWithTimePeriodDto.StartedDate, 
                transactionWithTimePeriodDto.EndedDate);

            if (transactions == null)
                throw new Exception(ErrorMessages.NullParemeter);

            if (transactions.Count == 0)
                throw new Exception(ErrorMessages.ZeroCount);

            var transactionsDto = _mapper.Map<List<BankTransactionDto>>(transactions);

            return transactionsDto;
        }

    }
}
