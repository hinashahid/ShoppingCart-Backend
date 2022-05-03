using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Interfaces;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}
