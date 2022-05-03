using MediatR;
using MyShoppingCart.Application.Interfaces;
using AutoMapper;
using MyShoppingCart.Application.Models;

namespace MyShoppingCart.Application.Queries.GetCountries;

public class GetCountriesQuery : IRequest<List<CountryViewModel>>
{

}
public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryViewModel>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    public GetCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<List<CountryViewModel>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);
        return countries.Select(x => _mapper.Map<CountryViewModel>(x)).ToList();
    }
}
