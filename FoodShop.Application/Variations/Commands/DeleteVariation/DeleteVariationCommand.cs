using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.Variations.Commands.DeleteVariation;

public record DeleteVariationCommand(Guid Id):ICommand;