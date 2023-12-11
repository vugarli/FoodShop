using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.VariationOptions.Commands.DeleteVariationOption;

public record DeleteVariationOptionCommand(Guid Id) : ICommand;