using AutoFixture;
using MyShoppingCart.Application.Commands.PlaceOrder;
using MyShoppingCart.WebApi.Request;
using Shouldly;
using System.Linq;
using Xunit;

namespace MyShoppingCart.WebApi.UnitTests
{
    public class ProfileTests : TestBase
    {
		[Fact]
		public void Map_RequestCommand_MappedCorrectly()
		{
			var request = Fixture.Build<PlaceOrderRequest>().Create();

			var command = Mapper.Map<PlaceOrderCommand>(request);

			command.Currency.ShouldBe(request.Currency);
			command.ExchangeRate.ShouldBe(request.ExchangeRate);
			command.ShippingCost.ShouldBe(request.ShippingCost);
			command.TotalCost.ShouldBe(request.TotalCost);
			foreach (var item in command.Items)
			{
				var requestItem = request.Items.FirstOrDefault(d => d.Product.Id == item.Product.Id);
				requestItem.ShouldNotBeNull();
				
				item.Quantity.ShouldBe(requestItem.Quantity);
				item.TotalPrice.ShouldBe(requestItem.TotalPrice);
				item.Product.ShouldNotBeNull();

				item.Product.Name.ShouldBe(requestItem.Product.Name);
				item.Product.UnitPrice.ShouldBe(requestItem.Product.UnitPrice);
				item.Product.ImageUrl.ShouldBe(requestItem.Product.ImageUrl);
			}
		}
	}
}