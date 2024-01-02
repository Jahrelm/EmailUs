using EmailFlow.Data;
using EmailFlow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailFlow.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailDbContext _dbContext;

        public MailController(MailDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostMail>>> GetMails()
        {
            if(_dbContext.PostMails == null)
            {
                return NotFound();
            }
            return await _dbContext.PostMails.ToListAsync();

        }

        [HttpGet("GetMailById/{id}")]
        public async Task<ActionResult<PostMail>> GetMail(int id)
        {
            if (_dbContext.PostMails == null)
            {
                return NotFound();
            }

            var postmail = await _dbContext.PostMails.FindAsync(id);

            if(postmail == null)
            {
                return NotFound();
            }
            return postmail;

        }
        [HttpPost]
        public async Task<ActionResult<PostMail>> PostMail(PostMail Mail) {


            _dbContext.PostMails.Add(Mail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMail), new {id = Mail.ID }, Mail);
        }
        [HttpDelete("DeleteMailById/{id}")]

        public async Task<IActionResult> DeleteMail(int id)
        {
            if(_dbContext.PostMails == null)
            {
                return NotFound();
            }

            var mail = await _dbContext.PostMails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _dbContext.PostMails.Remove(mail);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }



    }
}
