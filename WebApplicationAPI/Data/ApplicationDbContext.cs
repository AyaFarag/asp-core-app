using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // abstract class
        }

        public DbSet<Product> Products { get; set; }

    }
}
