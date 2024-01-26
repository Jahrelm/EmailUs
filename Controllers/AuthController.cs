using EmailFlowApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController() 
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
