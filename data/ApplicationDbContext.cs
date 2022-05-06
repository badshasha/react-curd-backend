using Microsoft.EntityFrameworkCore;
using it.Model;

namespace it.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Blogger> bloggers { get; set; }

    }
}
