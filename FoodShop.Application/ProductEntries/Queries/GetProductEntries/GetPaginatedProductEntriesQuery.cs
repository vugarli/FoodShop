using FoodShop.Application.Pagination;
using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public record GetPaginatedProductEntriesQuery() : IRequest<PaginatedResult<ProductEntryDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
