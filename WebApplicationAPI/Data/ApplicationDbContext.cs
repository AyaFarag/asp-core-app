using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole , string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // abstract class
        }

        //public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
