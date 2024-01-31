using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Products;

namespace FoodShop.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
{

    public UpdateProductCommandValidator(IProductRepository repository)
    {
        
        RuleFor(c => c.Id)
            .MustAsync(async (Id,canceltoken) =>
            {
                var spec = new ProductByIdSpecification(Id);
                return await repository.CheckProductBySpecification(spec);
            })
            .WithMessage("Provided Id does not match to a product!");
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.CategoryId).NotEmpty();
        RuleFor(p => p.Image).NotEmpty();
    }
    
}