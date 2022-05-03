using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken);
    }
}
