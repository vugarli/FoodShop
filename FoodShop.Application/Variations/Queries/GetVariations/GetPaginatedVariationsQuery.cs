using FoodShop.Application.Pagination;
using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public record GetPaginatedVariationsQuery() : IRequest<PaginatedResult<VariationDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
