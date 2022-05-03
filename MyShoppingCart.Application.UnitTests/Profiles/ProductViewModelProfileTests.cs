using AutoFixture;
using MyShoppingCart.Application.Models;
using MyShoppingCart.Domain.Entities;
using Shouldly;
using Xunit;

namespace MyShoppingCart.Application.UnitTests.Profiles
{
    public class ProductViewModelProfileTests : TestBase
    {
		[Fact]
		public void Map_ProductToProductViewModel_MappedCorrectly()
		{
			var product = Fixture.Build<Product>().Create();

			var productViewModel = Mapper.Map<ProductViewModel>(product);

			productViewModel.Id.ShouldBe(product.Id);
			productViewModel.Name.ShouldBe(product.Name);
			productViewModel.ImageUrl.ShouldBe(product.ImageUrl);
			productViewModel.UnitPrice.ShouldBe(product.UnitPrice);
		}
	}
}
