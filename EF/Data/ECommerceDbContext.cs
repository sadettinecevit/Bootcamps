using Microsoft.EntityFrameworkCore;

namespace EF.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) 
        {

        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }


    }
}
