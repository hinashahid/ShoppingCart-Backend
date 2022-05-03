using Microsoft.Extensions.Logging;
using Moq;
using MyShoppingCart.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace MyShoppingCart.Persistence.UnitTests
{
    public class CountryRepositoryTests :TestBase
    {
        private readonly Mock<ILogger<CountryRepository>> _mockLogger;
        private readonly CountryRepository _sut;

        public CountryRepositoryTests()
        {
            _mockLogger = new Mock<ILogger<CountryRepository>>();
            _sut = new CountryRepository(Context, _mockLogger.Object);
        }

        [Fact]
        public async void Test_WhenCountryListExist_GetCountriesList()
        {
            var countries = await _sut.GetCountriesAsync(default);
            countries.Count.ShouldBeGreaterThan(0);
        }


    }
}
