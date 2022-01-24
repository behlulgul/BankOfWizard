using BankOfWizard.Identity.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BankOfWizard.Identity.Jwt
{
    public interface IJwtFactory
    {
        Task<TokenViewModel> GenerateJwtTokenAsync(IdentityUser user, UserManager<IdentityUser> _userManager);
    }
}
