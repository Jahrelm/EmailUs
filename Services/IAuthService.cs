using EmailFlowApi.Models;

namespace EmailFlowApi.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(Login user);
    }
}