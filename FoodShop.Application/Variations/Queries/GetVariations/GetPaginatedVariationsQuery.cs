using FoodShop.Application.Queries;
using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public record GetPaginatedVariationsQuery() : IRequest<PaginatedQueryResult<VariationDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
