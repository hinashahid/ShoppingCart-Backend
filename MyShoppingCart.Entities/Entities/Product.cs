namespace MyShoppingCart.Domain.Entities;

public class Product
{
    public Product()
    {
        Name = "";
        ImageUrl = "";
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Decimal UnitPrice { get; set; }
    public string ImageUrl { get; set; }
}
