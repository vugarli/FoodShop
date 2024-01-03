using FoodShop.Application.Queries;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public record GetPaginatedCategoriesQuery() : IRequest<PaginatedQueryResult<CategoryDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
