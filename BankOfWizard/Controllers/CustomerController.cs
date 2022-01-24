using BankOfWizard.App.AccountServices.Dto;
using BankOfWizard.App.CustomerServices.Dto;
using BankOfWizard.App.Interfaces;
using BankOfWizard.Repository.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BankOfWizard.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateNewCustomer")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> CreateNewCustomer(HttpRequestObject<CreateCustomerDto> customerCreateRequest)
        {
            var customer = customerCreateRequest.Items.First();

            var result = await _customerService.CreateNewCustomer(customer);

            return new HttpResponseObjectSuccess<string>(result.ToString());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllCustomerAccounts")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<List<AccountDto>>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<List<AccountDto>>), (int)HttpStatusCode.BadRequest)]
        public async Task<HttpResponseObject<List<AccountDto>>> GetAllCustomerAccounts([FromQuery] GetCustomerAccountsDto getCustomerAccountsRequest)
        {
            var customerId = getCustomerAccountsRequest;

            var result = await _customerService.GetAllCustomerAccounts(customerId);

            return new HttpResponseObjectSuccess<List<AccountDto>>(result);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetCustomerAccountInfo")]
        public async Task<HttpResponseObject<AccountDto>> GetCustomerAccountInfo([FromQuery] GetCustomerAccountInfoDto getCustomerAccountsRequest)
        {
            var getCustomerAccountsRequestParams = getCustomerAccountsRequest;

            var result = await _customerService.GetCustomerAccountInfo(getCustomerAccountsRequestParams);

            return new HttpResponseObjectSuccess<AccountDto>(result);
        }
    }
}
