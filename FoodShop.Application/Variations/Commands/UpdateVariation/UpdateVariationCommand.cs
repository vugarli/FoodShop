using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using FoodShop.Application.VariationOptions.Commands.CreateVariationOption;
using FoodShop.Application.Variations.Commands.CreateVariation;

namespace FoodShop.Application.Variations.Commands.UpdateVariation;


public record VariationUpdateVariationOptionDto(Guid Id, string Value, string Name);

public record UpdateVariationCommand(Guid Id,string Name, IEnumerable<VariationUpdateVariationOptionDto>? VariationOptions) :ICommand<VariationDto>;