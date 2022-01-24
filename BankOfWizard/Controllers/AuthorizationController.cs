using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BankOfWizard.Identity.Domain;
using BankOfWizard.Identity.Jwt;
using BankOfWizard.Identity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankOfWizard.Controllers
{
    [Authorize()]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthorizationController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, UserManager<IdentityUser> userManager)
        {
            _jwtFactory = jwtFactory;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenViewModel>> Login([FromBody] CredentialsPersistanceModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(credentials.UserName) || string.IsNullOrEmpty(credentials.Password))
            {
                return StatusCode(StatusCodes.Status200OK, "login_failure");
            }
            var userToVerify = await _userManager.FindByNameAsync(credentials.UserName);
            if (userToVerify == null)
            {
                return StatusCode(StatusCodes.Status200OK, "login_failure");
            }
            else if (userToVerify.EmailConfirmed && await _userManager.CheckPasswordAsync(userToVerify, credentials.Password))
            {
                var jwt = await _jwtFactory.GenerateJwtTokenAsync(userToVerify, _userManager);
                return StatusCode(StatusCodes.Status200OK, jwt);
            }
            else
            {
                await _userManager.AccessFailedAsync(userToVerify);
                return StatusCode(StatusCodes.Status200OK, "login_failure");
            }
        }

    }
}
