using Microsoft.Extensions.Logging;
using MyShoppingCart.Application.Interfaces;
using MyShoppingCart.Domain.Entities;

namespace MyShoppingCart.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _context;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(IDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task PlaceOrderAsync(Order order, CancellationToken cancellationToken)
        {
            try
            {
                _context.Orders.Add(new Order
                {
                    Id = order.Id,
                    CreateDate = DateTime.UtcNow,
                    Currency = order.Currency,
                    ExchangeRate = order.ExchangeRate,
                    Items = order.Items,
                    ShippingCost = order.ShippingCost,
                    TotalCost = order.TotalCost
                });
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured in PlaceOrderAsync - {ex.Message}");
                throw;
            }
        }
    }
}
