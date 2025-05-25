using Microsoft.EntityFrameworkCore;
using WebApplication33.Models;

namespace WebApplication33
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // abstract class
        }

        public DbSet<User> users { get; set; }

    }
}
