using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariationById;

public record GetVariationByIdQuery(Guid Id) :IRequest<VariationDto>;