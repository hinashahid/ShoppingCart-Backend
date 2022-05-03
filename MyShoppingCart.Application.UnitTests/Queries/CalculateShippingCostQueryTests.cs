using MyShoppingCart.Application.Queries.CalculateShippingCost;
using Xunit;
using Shouldly;
namespace MyShoppingCart.Application.UnitTests.Queries
{
    public class CalculateShippingCostQueryHandlerTests : TestBase
    {
        private readonly CalculateShippingCostQueryHandler _sut;

        public CalculateShippingCostQueryHandlerTests()
        {
            _sut = new CalculateShippingCostQueryHandler();
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(10, 10)]
        [InlineData(20, 10)]
        [InlineData(50, 10)]
        [InlineData(51, 20)]
        [InlineData(100, 20)]
        [InlineData(1000, 20)]
        [InlineData(-10, 0)]
        public async void Handle_ReturnsCorrectShippingCost(decimal totalCost, decimal shippingCost)
        {
            var response = await _sut.Handle(new CalculateShippingCostQuery
            {
                TotalCost = totalCost
            }, default);

            response.ToString().ShouldBe(shippingCost.ToString());
        }

    }
}
