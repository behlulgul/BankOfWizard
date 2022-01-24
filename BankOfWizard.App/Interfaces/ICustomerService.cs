
using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.App.CustomerServices.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfWizard.App.Interfaces
{
    public interface ICustomerService
    {
        Task<Guid> CreateNewCustomer(CreateCustomerDto customerDto);

        Task<List<AccountDto>> GetAllCustomerAccounts(GetCustomerAccountsDto getCustomerAccountsDto);

        Task<AccountDto> GetCustomerAccountInfo(GetCustomerAccountInfoDto getCustomerAccountInfoDto);
    }
}
