 using EmailFlow.Data;
using EmailFlow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private readonly MailDbContext _dbContext;
        
        public RecipientController(MailDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("GetAllRecipients")]
        public async Task<ActionResult<IEnumerable<Recipient>>> GetRecipients()
        {
            if(_dbContext.Recipients == null)
            {
                return NotFound();
            }
            return await _dbContext.Recipients.ToListAsync();
        }
        [HttpGet("GetRecipientById/{id}")]
        public async Task<ActionResult<Recipient>> GetRecipient(int id)
        {
            if(_dbContext.Recipients == null)
            {
                return NotFound();
            }
            var recipient = await _dbContext.Recipients.FindAsync(id);
           
            if(recipient == null)
            {
                return NotFound();
            }
            return recipient;
        }

        [HttpPost]
        public async Task<ActionResult<Recipient>> PostRecipient(Recipient recipient)
        {
            _dbContext.Recipients.Add(recipient);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipients), new { id = recipient.RecipientId }, recipient);

        }

        [HttpPost("DeleteRecipientById/{id}")]

        public async Task<IActionResult> DeleteRecipient(int id)
        {
            if(_dbContext.Recipients == null)
            {
                return NotFound();
            }
            var getrecipient = await _dbContext.Recipients.FindAsync(id);

            if (getrecipient == null)
            {
                return NotFound();
            }
            _dbContext.Recipients.Remove(getrecipient);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("AddToGroup/{groupId}")]

        public async Task<ActionResult<Recipient>> RecipientToGroup(int groupId, Recipient recipient)
        {
            var group = await _dbContext.Groups.FindAsync(groupId);
            
            if (group == null)
            {
                return NotFound($"Group with id {groupId} not found");
            }

            recipient.GroupID = groupId;
            _dbContext.Recipients.Add(recipient);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipient), new { id = recipient.RecipientId }, recipient);

        }

    }
}
