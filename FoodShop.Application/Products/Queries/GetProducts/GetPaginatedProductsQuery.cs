using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Products.Queries.GetProducts;

public class GetPaginatedProductsQuery : IRequest<PaginatedResult<ProductDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}