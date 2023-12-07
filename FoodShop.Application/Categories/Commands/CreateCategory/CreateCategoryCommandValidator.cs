using FluentValidation;

namespace FoodShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name must be non empty string!");
        
    }
}