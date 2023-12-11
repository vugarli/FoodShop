using FoodShop.Application.Abstractions.CQSegregationInterfaces;

namespace FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;

public record UpdateVariationOptionCommand(Guid Id, string Value,Guid VariationId) : ICommand<VariationOptionDto>;