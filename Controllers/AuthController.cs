using EmailFlowApi.Models;
using EmailFlowApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthenticationService authService) 
        {  


        }
        
      
        [HttpPost]

        public async Task<bool> RegisterUser(Login user)
        {

        }
      
        [HttpGet]
        public async Task Login(Login user)
        {

        }
    }
}
