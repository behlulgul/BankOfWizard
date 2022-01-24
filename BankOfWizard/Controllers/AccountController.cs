using BankOfWizard.App.AccountServices.Dto;
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

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateNewAccount")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]

        public async Task<ActionResult<HttpResponseObject<string>>> CreateNewAccount(HttpRequestObject<CreateAccountDto> accountCreateRequest)
        {
            var accountCreateReq = accountCreateRequest.Items.First();

            var accountId = await _accountService.CreateNewAccount(accountCreateReq);

            return new HttpResponseObjectSuccess<string>(accountId.ToString());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("WithDrawMoneyFromAccount")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
        ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> WithDrawMoneyFromAccount(HttpRequestObject<WithdrawMoneyFromAccountDto> withdrawMoneyRequest)
        {
            var request = withdrawMoneyRequest.Items.First();

            await _accountService.WithDrawMoneyFromAccount(request);

            return new HttpResponseObjectSuccess<string>(request.AccountId.ToString());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("AddMoneyToAccount")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<string>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<string>>> AddMoneyToAccount(HttpRequestObject<AddMoneyToAccountDto> addMoneyRequest)
        {
            var addMoneyReq = addMoneyRequest.Items.First();

            await _accountService.AddMoneyToAccount(addMoneyReq);

            return new HttpResponseObjectSuccess<string>(addMoneyReq.AccountId.ToString());
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAccountTransactionBetweenPeriod")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<BankTransactionDto>), (int)HttpStatusCode.OK),
        ProducesResponseType(typeof(HttpResponseObjectError<BankTransactionDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<HttpResponseObject<List<BankTransactionDto>>> GetAccountTransactionBetweenPeriod([FromQuery]GetAccountAllTransactionsBetweenTimePeriodDto GetAccountTransactionWithTimePerioRequest)
        {
            var GetAccountTransactionWithTimePerioReq = GetAccountTransactionWithTimePerioRequest;

            var transactions = await _accountService.GetAccountTransactionBetweenPeriod(GetAccountTransactionWithTimePerioReq);

            return new HttpResponseObjectSuccess<List<BankTransactionDto>>(transactions);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllAccountTransactions")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<BankTransactionDto>), (int)HttpStatusCode.OK),
        ProducesResponseType(typeof(HttpResponseObjectError<BankTransactionDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<HttpResponseObject<List<BankTransactionDto>>> GetAllAccountTransactions([FromQuery]GetAccountAllTransactionsDto getAccountTransactionRequest)
        {
            var getAccountTransactionReq = getAccountTransactionRequest;

            var transactions = await _accountService.GetAccountAllTransactions(getAccountTransactionReq);

            return new HttpResponseObjectSuccess<List<BankTransactionDto>>(transactions);
        }


    }
}
