using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyShoppingCart.Application.Interfaces;
using AutoMapper;
using MyShoppingCart.Application.Models;

namespace MyShoppingCart.Application.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
{

}
/// <summary>
/// Handler to get all products.
/// Calls products repository to get the data
/// </summary>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products =  await _productRepository.GetProductsAsync(cancellationToken);
        return products.Select(x => _mapper.Map<ProductViewModel>(x)).ToList(); //map results to view model
    }
}
