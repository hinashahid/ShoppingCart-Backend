using Microsoft.EntityFrameworkCore;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
