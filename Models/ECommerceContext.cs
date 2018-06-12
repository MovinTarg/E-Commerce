using Microsoft.EntityFrameworkCore;
 
namespace E_Commerce.Models
{
    public class ECommerceContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}