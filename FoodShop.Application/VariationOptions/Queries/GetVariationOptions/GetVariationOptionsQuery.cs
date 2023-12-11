using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public record GetVariationOptionsQuery() : IRequest<IEnumerable<VariationOptionDto>>;