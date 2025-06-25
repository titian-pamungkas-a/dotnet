using EmptyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
