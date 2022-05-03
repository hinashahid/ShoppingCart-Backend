using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;
using System;
using System.Linq;
namespace MyShoppingCart.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbContext _context;
    private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(IDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        try
        {

        await AddStaticData(cancellationToken); //Just for this use-case when we need static list.
        return await _context.Products.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured in GetProductsAsync - {ex.Message}");
            throw;
        }


    }

    private async Task AddStaticData(CancellationToken cancellationToken)
    {
        var products = new List<Product>();
        for (int i = 0; i < 80; i++)
        {
            var productId = Guid.NewGuid();
            var imageId = i;
            var price = (decimal)(imageId + 20.5);
            products.Add(new Product
            {
                Id = productId,
                Name = $"Product-{imageId}",
                ImageUrl = $"https://picsum.photos/id/{imageId}",
                UnitPrice = price
            });
        }
        _context.Products.AddRange(products);
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}