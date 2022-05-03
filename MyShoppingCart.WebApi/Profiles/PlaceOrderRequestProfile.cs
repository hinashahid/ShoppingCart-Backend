using AutoMapper;
using MyShoppingCart.Application.Commands.PlaceOrder;
using MyShoppingCart.Application.Models;
using MyShoppingCart.WebApi.Request;
using CommandCartItem = MyShoppingCart.Application.Commands.PlaceOrder.CartItem;
namespace MyShoppingCart.WebApi.Profiles
{
    public class PlaceOrderRequestProfile : Profile
    {
        public PlaceOrderRequestProfile()
        {
            CreateMap<PlaceOrderRequest, PlaceOrderCommand>();
            CreateMap<Request.CartItem, CommandCartItem>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
