using FoodShop.Application.Pagination;
using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public record GetPaginatedVariationOptionsQuery() : IRequest<PaginatedResult<VariationOptionDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
