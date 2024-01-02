using EmailFlow.Data;
using EmailFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace EmailFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        public readonly MailDbContext _dbContext;
         
        public GroupController(MailDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            try
            {
                var groups = await _dbContext.Groups.Include(g => g.Recipients).ToListAsync();

                if (groups == null || groups.Count == 0)
                {
                    return NotFound("No groups found.");
                }

                return groups;
            }
            catch (Exception ex)
            {
                // Handle exceptions according to your application's requirements
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("GetGroupById/{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            try
            {
                var group = await _dbContext.Groups
                    .Include(g => g.Recipients)
                    .FirstOrDefaultAsync(g => g.GroupID == id);

                if (group == null)
                {
                    return NotFound($"Group with id {id} not found");
                }

                return group;
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = group.GroupID }, group);
        }

        [HttpDelete("DeleteGroupById/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (_dbContext.Groups == null)
            {
                return NotFound();
            }

            var group = await _dbContext.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }

    }

}
