namespace MyShoppingCart.WebApi.Request
{
    public class PlaceOrderRequest
    {
        public List<CartItem> Items { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Currency { get; set; }
        public float ExchangeRate { get; set; }
    }
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
