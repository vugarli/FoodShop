using System.Data;
using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Variations.Commands.CreateVariation;

public class CreateVariationCommandValidator : AbstractValidator<CreateVariationCommand>
{
    

    public CreateVariationCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(v => v.Name).NotEmpty()
            .WithMessage("Variation should not be empty!");
        RuleFor(v => v.CategoryId).NotEmpty()
            .WithMessage("Category Id should not be empty!");
        RuleFor(v => v.CategoryId)
            .MustAsync(async (cid,cancellationtoken) => await categoryRepository.CategoryExistsAsync(cid,cancellationtoken))
            .WithMessage("Category with specified Id does not exist!");
    }
    
}