using EmailFlowApi.Data;
using EmailFlowApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace EmailFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly AuthDbContext _dbContext;

        public AuthController(UserManager<IdentityUser> userManager, AuthDbContext dbContext) 
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = model.Email,  
                Email = model.Email
            };

           
            var result = await _userManager.CreateAsync(user, model.Password);
            _dbContext.Add(model);
            await _dbContext.SaveChangesAsync();

            

            if (result.Succeeded)
            {
                return Ok(new { message = "User created successfully" });
            }
            else
            {
                // Return the errors if the creation failed
                return BadRequest(result.Errors);
            }
        }
    }
}
