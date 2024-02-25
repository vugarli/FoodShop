using FluentValidation;

namespace FoodShop.Application.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name can not be empty!");
        RuleFor(c => c.Description).NotEmpty().WithMessage($"{nameof(CreateProductCommand.Description)} can not empty!");
        RuleFor(c => c.CategoryId).NotEmpty().WithMessage($"{nameof(CreateProductCommand.CategoryId)} can not empty!");
        RuleFor(c => c.Image).NotEmpty().WithMessage($"{nameof(CreateProductCommand.Image)} can not empty!");
    }
}