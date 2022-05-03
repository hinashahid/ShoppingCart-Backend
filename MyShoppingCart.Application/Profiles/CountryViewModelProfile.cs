using AutoMapper;
using MyShoppingCart.Application.Models;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Profiles;

public class CountryViewModelProfile : Profile
{
    public CountryViewModelProfile()
    {
        CreateMap<Country, CountryViewModel>();
    }
}
