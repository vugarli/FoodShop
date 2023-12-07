using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Variations.Commands.CreateVariation;

public record CreateVariationCommand(string Name,Guid CategoryId):ICommand<VariationDto>;