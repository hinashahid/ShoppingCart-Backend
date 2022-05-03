using AutoFixture;
using Moq;
using MyShoppingCart.Application.Commands.PlaceOrder;
using MyShoppingCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.UnitTests.Commands
{
    public class PlaceOrderCommandHandlerTests : TestBase
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        private readonly PlaceOrderCommandHandler _sut;

        private PlaceOrderCommand _command;

        public PlaceOrderCommandHandlerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _sut = new PlaceOrderCommandHandler(_mockOrderRepository.Object);
        }
        
        [Fact]
        public void Handle_WhenNoItemsExist_ThrowsException()
        {
            Setup(() => _command.Items = new List<CartItem>());

            Should.Throw<ArgumentNullException>(async() => await _sut.Handle(_command, default));
        }

        [Fact]
        public void Handle_WhenNullItems_ThrowsException()
        {
            Setup(() => _command.Items = null);

            Should.Throw<ArgumentNullException>(async () => await _sut.Handle(_command, default));
        }

        [Fact]
        public void Handle_WhenValidOrderPassed_ShouldPlaceOrder()
        {
            Setup();

            Should.NotThrow(async () => await _sut.Handle(_command, default));
            _mockOrderRepository.Verify(x => x.PlaceOrderAsync(It.Is<Order>(o => o.Items.Count == _command.Items.Count && o.TotalCost == _command.TotalCost), default));
        }

        private void Setup(Action? action = null)
        {
            _command = Fixture.Build<PlaceOrderCommand>().Create();
            action?.Invoke();
        }
    }
}
