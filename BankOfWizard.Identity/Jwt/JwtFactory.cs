using BankOfWizard.Identity.Domain;
using BankOfWizard.Identity.Helpers;
using BankOfWizard.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BankOfWizard.Identity.Jwt
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }
        public async Task<TokenViewModel> GenerateJwtTokenAsync(IdentityUser user,  UserManager<IdentityUser> userManager)
        {
            var identiyclaims = new List<Claim>();
            var roles=await userManager.GetRolesAsync(user);
            identiyclaims.Add(new Claim(Constants.Strings.JwtClaimIdentifiers.Id, user.Id.ToString()));
            identiyclaims.Add(new Claim(Constants.Strings.JwtClaimIdentifiers.EMail, user.Email.ToString()));
            identiyclaims.Add(new Claim(Constants.Strings.JwtClaimIdentifiers.UserName, user.UserName.ToString()));
            foreach (var role in roles)
            {
                identiyclaims.Add(new Claim(ClaimTypes.Role, role.ToString()));

            }

            var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"), identiyclaims);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
            };
 
            identiyclaims.ToList().ForEach(dr => claims.Add(identity.FindFirst(dr.Type)));

            var jwt = new JwtSecurityToken(
                  issuer: _jwtOptions.Issuer,
                  audience: _jwtOptions.Audience,
                  claims: claims,
                  notBefore: _jwtOptions.NotBefore,
                  expires: _jwtOptions.Expiration,
                  signingCredentials: _jwtOptions.SigningCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new TokenViewModel
            {
                id = identity.Claims.Single(c => c.Type == Constants.Strings.JwtClaimIdentifiers.Id).Value,
                email = identity.Claims.Single(c => c.Type == Constants.Strings.JwtClaimIdentifiers.EMail).Value,
                user_name = identity.Claims.Single(c => c.Type == Constants.Strings.JwtClaimIdentifiers.UserName).Value,
                auth_token = token,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
            };

            return response;
        }
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
