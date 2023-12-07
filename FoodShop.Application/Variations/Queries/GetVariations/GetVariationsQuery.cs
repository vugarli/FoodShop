using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public record GetVariationsQuery():IRequest<IEnumerable<VariationDto>>;