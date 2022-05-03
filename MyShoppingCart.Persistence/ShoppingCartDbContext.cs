using Microsoft.EntityFrameworkCore;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Persistence;

public class ShoppingCartDbContext : DbContext, IDbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
    {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = true;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ShoppingCartDbContext).Assembly);
    }
}