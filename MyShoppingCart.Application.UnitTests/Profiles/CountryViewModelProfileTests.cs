using AutoFixture;
using MyShoppingCart.Application.Models;
using MyShoppingCart.Domain.Entities;
using Shouldly;
using Xunit;

namespace MyShoppingCart.Application.UnitTests.Profiles
{
    public class CountryViewModelProfileTests : TestBase
    {
		[Fact]
		public void Map_CountryToCountryViewModel_MappedCorrectly()
		{
			var country = Fixture.Build<Country>().Create();

			var countryViewModel = Mapper.Map<CountryViewModel>(country);

			countryViewModel.Currency.ShouldBe(country.Currency);
			countryViewModel.ExchangeRate.ShouldBe(country.ExchangeRate);
			countryViewModel.Name.ShouldBe(country.Name);
			countryViewModel.Symbol.ShouldBe(country.Symbol);
			countryViewModel.Id.ShouldBe(country.Id);
		}
	}
}
