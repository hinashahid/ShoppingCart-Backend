using MediatR;
using MyShoppingCart.Application.Models;

namespace MyShoppingCart.Application.Commands.PlaceOrder
{
    public class PlaceOrderCommand : IRequest
    {
        public List<CartItem> Items { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Currency { get; set; }
        public float ExchangeRate { get; set; }
    }
    public class CartItem
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
