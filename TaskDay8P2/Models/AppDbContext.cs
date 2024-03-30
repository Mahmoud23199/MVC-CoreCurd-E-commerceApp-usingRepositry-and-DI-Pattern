using Microsoft.EntityFrameworkCore;

namespace TaskDay8P2.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {
        }


    }
}
