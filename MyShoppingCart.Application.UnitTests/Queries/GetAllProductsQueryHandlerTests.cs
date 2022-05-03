using Moq;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Application.Queries.GetAllProducts;
using MyShoppingCart.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyShoppingCart.Application.UnitTests.Queries
{
    public class GetAllProductsQueryHandlerTests : TestBase
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly GetAllProductsQueryHandler _sut;
        public GetAllProductsQueryHandlerTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _sut = new GetAllProductsQueryHandler(_mockProductRepository.Object, Mapper);
        }

        [Fact]
        public async void Handle_WhenCountriesListReturnedFromRepository_ReturnsList()
        {
            var productsList = new List<Product> {
                new Product { Id = Guid.NewGuid(), Name = "Product1", ImageUrl ="test1", UnitPrice=10.5M },
                new Product { Id = Guid.NewGuid(), Name = "Product2", ImageUrl ="test2", UnitPrice=100.5M },
            };
            _mockProductRepository.Setup(s => s.GetProductsAsync(default)).ReturnsAsync(productsList);

            var products = await _sut.Handle(new GetAllProductsQuery(), default);
            products.ShouldNotBeEmpty();
            products.Count.ShouldBe(2);
            products.First().Id.ShouldBe(productsList.First().Id);
            products.First().Name.ShouldBe(productsList.First().Name);
            products.First().ImageUrl.ShouldBe(productsList.First().ImageUrl);
            products.First().UnitPrice.ShouldBe(productsList.First().UnitPrice);
            products.Last().Id.ShouldBe(productsList.Last().Id);
            products.Last().Name.ShouldBe(productsList.Last().Name);
            products.Last().ImageUrl.ShouldBe(productsList.Last().ImageUrl);
            products.Last().UnitPrice.ShouldBe(productsList.Last().UnitPrice);
        }

        [Fact]
        public void Handle_WhenRepositoryThrowsException_Throws()
        {
            _mockProductRepository.Setup(s => s.GetProductsAsync(default)).Throws<Exception>();

            Should.Throw<Exception>(async () => await _sut.Handle(new GetAllProductsQuery(), default));
        }

    }
}
