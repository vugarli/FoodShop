using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Products;

namespace FoodShop.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator(IProductRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (Id,c) =>
            {
                var spec = new ProductByIdSpecification(Id);
                return await repository.CheckProductBySpecification(spec);
            })
            .WithMessage("Provided Id does not match to a product!");
    }
}