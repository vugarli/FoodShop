using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, PaginatedResult<Product>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedResult<Product>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetPaginatedProductsAsync(request.page,request.per_page);
        var count = await _repository.GetProductsCountAsync();

        var pModel = new PaginatedResult<Product>(data,request.page,request.per_page,count);

        return pModel;
    }
}