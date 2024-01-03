using FoodShop.Application.Queries;
using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public record GetPaginatedVariationOptionsQuery() : IRequest<PaginatedQueryResult<VariationOptionDto>>, IPaginatedQuery
{
    public int page { get; init; }
    public int per_page { get; init; }
}
