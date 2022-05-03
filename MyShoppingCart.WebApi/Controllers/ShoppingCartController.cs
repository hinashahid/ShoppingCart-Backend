using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyShoppingCart.Application.Commands.PlaceOrder;
using MyShoppingCart.Application.Models;
using MyShoppingCart.Application.Queries.CalculateShippingCost;
using MyShoppingCart.Application.Queries.GetAllProducts;
using MyShoppingCart.Application.Queries.GetCountries;
using MyShoppingCart.WebApi.Request;

namespace MyShoppingCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ShoppingCartController(ILogger<ShoppingCartController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAllProducts))]
        public async Task<List<ProductViewModel>> GetAllProducts(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet(nameof(GetCountries))]
        public async Task<List<CountryViewModel>> GetCountries(CancellationToken cancellationToken)
        {
            var query = new GetCountriesQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet(nameof(CalculateShippingCost))]
        public Task<int> CalculateShippingCost(decimal totalCost, CancellationToken cancellationToken)
        {
            var query = new CalculateShippingCostQuery
            {
                TotalCost = totalCost
            };
            return _mediator.Send(query, cancellationToken);
        }

        [HttpPost(nameof(PlaceOrder))]
        public async Task PlaceOrder(PlaceOrderRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<PlaceOrderCommand>(request);
            await _mediator.Send(command, cancellationToken);
        }
    }
}
