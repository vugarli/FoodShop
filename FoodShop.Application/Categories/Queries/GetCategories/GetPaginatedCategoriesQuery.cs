using FoodShop.Application.Pagination;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public record GetPaginatedCategoriesQuery() : IRequest<PaginatedResult<CategoryDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
