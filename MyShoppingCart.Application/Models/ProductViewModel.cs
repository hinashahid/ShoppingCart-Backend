namespace MyShoppingCart.Application.Models;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public string ImageUrl { get; set; }
}
