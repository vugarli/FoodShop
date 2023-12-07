using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Variations.Commands.UpdateVariation;

public class UpdateVariationCommandValidator : AbstractValidator<UpdateVariationCommand>
{
    public UpdateVariationCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(v => v.Name).NotEmpty()
            .WithMessage("Variation name should not be empty!");
        RuleFor(v => v.CategoryId).NotEmpty()
            .WithMessage("Category Id should not be empty!");
        RuleFor(v => v.CategoryId)
            .MustAsync(async (cid,cancellationtoken) => await categoryRepository.CategoryExistsAsync(cid,cancellationtoken))
            .WithMessage("Category with specified Id does not exist!");
    }
}