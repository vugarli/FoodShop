using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptionById;

public record GetVariationOptionByIdQuery(Guid Id) : IRequest<VariationOptionDto>;