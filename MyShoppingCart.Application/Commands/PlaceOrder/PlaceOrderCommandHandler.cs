using MediatR;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Application.Commands.PlaceOrder;

public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    public PlaceOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Unit> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        //donot proceed if no items are provided in the order
        if (command.Items == null || command.Items.Count == 0) throw new ArgumentNullException("No items provided for the order.");
        
        var orderId = Guid.NewGuid();
        var order = new Order
        {
            Id = orderId,
            CreateDate = DateTime.UtcNow,
            Currency = command.Currency,
            ExchangeRate = command.ExchangeRate,
            Items = command.Items.Select(s => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = s.Product.Id,
                Quantity = s.Quantity,
                UnitPrice = s.Product.UnitPrice
            }).ToList(),
            ShippingCost = command.ShippingCost,
            TotalCost = command.TotalCost
        };

        await _orderRepository.PlaceOrderAsync(order, cancellationToken);
        return Unit.Value;
    }
}
