using AutoMapper;
using MyShoppingCart.Application.Models;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Profiles
{
    public class ProductViewModelProfile : Profile
    {
        public ProductViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
