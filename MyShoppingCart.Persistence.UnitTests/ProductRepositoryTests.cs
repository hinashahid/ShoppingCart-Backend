using Microsoft.Extensions.Logging;
using Moq;
using MyShoppingCart.Persistence.Repositories;
using Xunit;
using Shouldly;

namespace MyShoppingCart.Persistence.UnitTests
{
    public class ProductRepositoryTests :TestBase
    {
        private readonly Mock<ILogger<ProductRepository>> _mockLogger;
        private readonly ProductRepository _sut;

        public ProductRepositoryTests()
        {
            _mockLogger = new Mock<ILogger<ProductRepository>>();
            _sut = new ProductRepository(Context, _mockLogger.Object);
        }

        [Fact]
        public async void Test_WhenProductsListExist_GetProductsList()
        {
            var products = await _sut.GetProductsAsync(default);
            products.Count.ShouldBeGreaterThan(0);
        }


    }
}
