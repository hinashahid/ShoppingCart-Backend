using MediatR;
namespace MyShoppingCart.Application.Queries.CalculateShippingCost;

public class CalculateShippingCostQuery : IRequest<int>
{
    public decimal TotalCost { get; set; }
}
public class CalculateShippingCostQueryHandler : IRequestHandler<CalculateShippingCostQuery, int>
{    
    public Task<int> Handle(CalculateShippingCostQuery request, CancellationToken cancellationToken)
    {
        if (request.TotalCost <= 0) return Task.FromResult(0);
        return Task.FromResult(request.TotalCost <= 50 ? 10 : 20);
    }
}
