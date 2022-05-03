using Microsoft.Extensions.Logging;
using Moq;
using MyShoppingCart.Persistence.Repositories;
using Xunit;
using Shouldly;
using MyShoppingCart.Domain.Entities;
using AutoFixture;
using System.Linq;
using MyShoppingCart.Application.Interfaces;

namespace MyShoppingCart.Persistence.UnitTests
{
    public class OrderRepositoryTests : TestBase
    {
        private readonly Mock<ILogger<OrderRepository>> _mockLogger;
        private readonly IOrderRepository _sut;

        public OrderRepositoryTests()
        {
            _mockLogger = new Mock<ILogger<OrderRepository>>();
            _sut = new OrderRepository(Context, _mockLogger.Object);
        }

        [Fact]
        public async void Test_WhenOrderIsPlaced_AddRecordToDb()
        {
            var order = Fixture.Build<Order>().Create();
            await _sut.PlaceOrderAsync(order, default);
            Context.Orders.ToList().Count.ShouldBe(1);
            Context.OrderItems.ToList().Count.ShouldBe(order.Items.Count);
        }
    }
}
