using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.VariationOptions.Commands.CreateVariationOption;

public record CreateVariationOptionCommand(Guid VariationId,string Value) : ICommand<VariationOptionDto>;