using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using FoodShop.Application.VariationOptions;
using FoodShop.Application.VariationOptions.Commands.CreateVariationOption;

namespace FoodShop.Application.Variations.Commands.CreateVariation;

public record VariationVariationOptionCreateDto(string Value,string Name);

public record CreateVariationCommand(string Name,IEnumerable<VariationVariationOptionCreateDto>? VariationOptions):ICommand<VariationDto>;