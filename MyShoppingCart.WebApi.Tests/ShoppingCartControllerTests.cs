using AutoFixture;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using MyShoppingCart.Application.Commands.PlaceOrder;
using MyShoppingCart.Application.Queries.CalculateShippingCost;
using MyShoppingCart.Application.Queries.GetAllProducts;
using MyShoppingCart.Application.Queries.GetCountries;
using MyShoppingCart.WebApi.Controllers;
using MyShoppingCart.WebApi.Request;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyShoppingCart.WebApi.UnitTests
{
    public class ShoppingCartControllerTests : TestBase
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<ShoppingCartController>> _mockLogger;
        private readonly ShoppingCartController _controller;
        public ShoppingCartControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<ShoppingCartController>>();
            _controller = new ShoppingCartController(_mockLogger.Object, _mockMediator.Object, Mapper);
        }

        [Fact]
        public async Task GivenGetAllProducts_ShouldCallGetAllProductsQuery()
        {
            await _controller.GetAllProducts(default);
            _mockMediator.Verify(d => d.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()));
        }
        
        [Fact]
        public async Task GivenGetAllProducts_ShouldCallGetCountriesQuery()
        {
            await _controller.GetCountries(default);
            _mockMediator.Verify(d => d.Send(It.IsAny<GetCountriesQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GivenCalculateShippingCost__ShouldCallCalculateShippingCostQuery()
        {
            var totalCost = 10;
            var shippingCost = await _controller.CalculateShippingCost(totalCost, default);
            _mockMediator.Verify(d => d.Send(It.Is<CalculateShippingCostQuery>(x=>x.TotalCost == totalCost), It.IsAny<CancellationToken>()));            
        }
        [Fact]
        public async Task GivenPlaceOrder__ShouldCallPlaceOrderCommand()
        {
            var request = Fixture.Create<PlaceOrderRequest>();
            await _controller.PlaceOrder(request, default);
            _mockMediator.Verify(d => d.Send(It.Is<PlaceOrderCommand>(x=>
                                x.Items.Count == request.Items.Count 
                                && x.TotalCost == request.TotalCost
                                && x.Currency == request.Currency
                                ), It.IsAny<CancellationToken>()));
        }
    }
}
