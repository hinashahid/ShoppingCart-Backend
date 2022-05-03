using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;
namespace MyShoppingCart.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly IDbContext _context;
    private readonly ILogger<CountryRepository> _logger;
    public CountryRepository(IDbContext context, ILogger<CountryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await AddStaticData(cancellationToken); //Add static data to db
            return await _context.Countries.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occured in GetCountriesAsync - {ex.Message}");
            throw;
        }
    }

    private async Task AddStaticData(CancellationToken cancellationToken)
    {
        _context.Countries.AddRange(
            new Country { Id = 1, Name = "United States of America", Currency = "USD", Symbol = "$", ExchangeRate = 0.71F },
            new Country { Id = 2, Name = "United Kingdom", Currency = "GBP", Symbol = "£", ExchangeRate = 0.56F },
            new Country { Id = 3, Name = "China", Currency = "CNY", Symbol = "元", ExchangeRate = 4.67F },
            new Country { Id = 4, Name = "Pakistan", Currency = "PKR", Symbol = "Rs.", ExchangeRate = 130.95F },
            new Country { Id = 5, Name = "India", Currency = "INR", Symbol = "Rs.", ExchangeRate = 54.05F }
                        );
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}