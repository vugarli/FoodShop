using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Variations.Commands.UpdateVariation;

public record UpdateVariationCommand(Guid Id,string Name,Guid CategoryId):ICommand<VariationDto>;