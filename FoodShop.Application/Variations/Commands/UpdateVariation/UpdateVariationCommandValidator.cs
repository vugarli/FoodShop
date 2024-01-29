using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Variations.Commands.UpdateVariation;

public class UpdateVariationCommandValidator : AbstractValidator<UpdateVariationCommand>
{
    public UpdateVariationCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(v => v.Name).NotEmpty()
            .WithMessage("Variation name should not be empty!");
    }
}