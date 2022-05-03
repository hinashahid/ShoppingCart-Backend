using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Interfaces;

public interface IOrderRepository
{
    Task PlaceOrderAsync(Order order, CancellationToken cancellationToken);
}
