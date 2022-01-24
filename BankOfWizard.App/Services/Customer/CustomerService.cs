using AutoMapper;
using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.App.Common;
using BankOfWizard.App.CustomerServices.Dto;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Domain.Customers;
using BankOfWizard.Domain.BusinessRulesMesages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfWizard.App.CustomerServices
{
    
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      
           public CustomerService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [Logging]
        public async Task<Guid> CreateNewCustomer(CreateCustomerDto customerDto)
        {
            if (customerDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var isCustomerAlreadyExist = _unitOfWork.CustomerRepository.GetCustomerByCustomerNumber(customerDto.CustomerNumber);

            if(isCustomerAlreadyExist)
                throw new Exception(ErrorMessages.CustomerAlreadyExist);

            var customer = Customer.Create(Guid.NewGuid(), customerDto.CustomerNumber, customerDto.Name, customerDto.Surname, customerDto.PhoneNumber, customerDto.City, customerDto.County);

            var customerId =  await _unitOfWork.CustomerRepository.CreateNewCustomer(customer);

            if (customerId == Guid.Empty)
                throw new Exception(ErrorMessages.AccountCouldNotCreated);

            _unitOfWork.Complete();

            return customerId;
        }

        [Logging]     
        public async Task<List<AccountDto>> GetAllCustomerAccounts(GetCustomerAccountsDto getCustomerAccountsDto)
        {
            if (getCustomerAccountsDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var customer = await _unitOfWork.CustomerRepository.GetCustomerById(getCustomerAccountsDto.CustomerId);

            if (customer == null)
                throw new Exception(ErrorMessages.CustomerNotFound);

            var accounts = await _unitOfWork.AccountRepository.GetCustomersAllAccount(getCustomerAccountsDto.CustomerId);

            if (accounts == null)
                throw new Exception(ErrorMessages.NullParemeter);

            if (accounts.Count == 0)
                throw new Exception(ErrorMessages.ZeroCount);

            var accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;

        }
       
        [Logging]
        public async Task<AccountDto> GetCustomerAccountInfo(GetCustomerAccountInfoDto getCustomerAccountInfoDto)
        {
            if (getCustomerAccountInfoDto == null)
                throw new Exception(ErrorMessages.NullParemeter);

            var customer =await _unitOfWork.CustomerRepository.GetCustomerById(getCustomerAccountInfoDto.CustomerId);

            if (customer==null)
                throw new Exception(ErrorMessages.CustomerNotFound);

            var account = await _unitOfWork.AccountRepository.GetAccountDetailsWithCustomerId(getCustomerAccountInfoDto.AccountId, getCustomerAccountInfoDto.CustomerId);

            if (account == null)
                throw new Exception(ErrorMessages.AccountAndCustomerNotMatch);

            var accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }
    }
}
