using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(IVariationRepository variationRepository)
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name must be non empty string!");
        RuleFor(c => c.Variations).MustAsync(async (a,cancel) =>
        {
            return await variationRepository.VariationsExistsAsync(a,cancel);
        }).When(c=>c.Variations != null).WithMessage("One or more variations not found!");
    }
}