using EmailFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailFlow.Data
{
    public class MailDbContext : DbContext
    {
        public MailDbContext(DbContextOptions<MailDbContext> options) : base(options)
        {
        }
        public DbSet<PostMail> PostMails { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
