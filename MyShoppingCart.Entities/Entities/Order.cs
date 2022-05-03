namespace MyShoppingCart.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Currency { get; set; }
        public float ExchangeRate { get; set; }
        public List<OrderItem> Items{ get; set; }
    }    
}
