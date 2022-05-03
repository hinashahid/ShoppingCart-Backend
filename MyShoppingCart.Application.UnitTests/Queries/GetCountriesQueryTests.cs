using AutoFixture;
using Moq;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Application.Queries.GetCountries;
using MyShoppingCart.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyShoppingCart.Application.UnitTests.Queries
{
    public class GetCountriesQueryTests : TestBase
    {
        private readonly Mock<ICountryRepository> _mockCountryRepository;
        private readonly GetCountriesQueryHandler _sut;
        public GetCountriesQueryTests()
        {
            _mockCountryRepository = new Mock<ICountryRepository>();
            _sut = new GetCountriesQueryHandler(_mockCountryRepository.Object, Mapper);
        }

        [Fact]
        public async void Handle_WhenCountriesListReturnedFromRepository_ReturnsList()
        {
            _mockCountryRepository.Setup(s => s.GetCountriesAsync(default)).ReturnsAsync(new List<Country> {
                new Country { Id = 1, Name = "United States of America", Currency = "USD", Symbol = "$", ExchangeRate = 0.71F },
                new Country { Id = 2, Name = "United Kingdom", Currency = "GBP", Symbol = "£", ExchangeRate = 0.56F },
            });

            var countries = await _sut.Handle(new GetCountriesQuery(), default);
            countries.ShouldNotBeEmpty();
            countries.Count.ShouldBe(2);
            countries.First().Id.ShouldBe(1);
            countries.First().Name.ShouldBe("United States of America");
            countries.Last().Id.ShouldBe(2);
            countries.Last().Name.ShouldBe("United Kingdom");
        }

        [Fact]
        public void Handle_WhenRepositoryThrowsException_Throws()
        {
            _mockCountryRepository.Setup(s => s.GetCountriesAsync(default)).Throws<Exception>();

            Should.Throw<Exception>(async () => await _sut.Handle(new GetCountriesQuery(), default));
        }

    }
}
