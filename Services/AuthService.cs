using EmailFlowApi.Models;
using Microsoft.AspNetCore.Identity;

namespace EmailFlowApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> RegisterUser(Login user)
        {
            var identityUser = new IdentityUser
            {
                Email = user.Email,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
    }
}
