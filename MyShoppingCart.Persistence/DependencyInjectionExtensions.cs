using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Persistence.Repositories;

namespace MyShoppingCart.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<IDbContext, ShoppingCartDbContext>(options =>
         {
             options.UseInMemoryDatabase(Guid.NewGuid().ToString());
         });
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        return services;
    }
}
