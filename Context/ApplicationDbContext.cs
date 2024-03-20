using Microsoft.EntityFrameworkCore;
using WebApiDotNetCore.Models;

namespace WebApiDotNetCore.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
            


    }
}
