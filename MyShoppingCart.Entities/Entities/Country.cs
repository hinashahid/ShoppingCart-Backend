namespace MyShoppingCart.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public string Symbol { get; set; }
    public float ExchangeRate { get; set; }
}
