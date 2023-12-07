using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
{

    public UpdateProductCommandValidator(IProductRepository repository)
    {
        
        RuleFor(c => c.Id)
            .MustAsync(async (Id,canceltoken) =>await repository.ProductExistsAsync(Id,canceltoken))
            .WithMessage("Provided Id does not match to a product!");
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.CategoryId).NotEmpty();
        RuleFor(p => p.Image).NotEmpty();
    }
    
}