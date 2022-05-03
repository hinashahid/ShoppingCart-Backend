using Microsoft.EntityFrameworkCore;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Persistence.UnitTests
{
    public class InMemoryDbContext : DbContext, IDbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


    }
}
