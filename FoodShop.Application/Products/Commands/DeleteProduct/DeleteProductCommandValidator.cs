using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator(IProductRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (Id,c) =>  await repository.ProductExistsAsync(Id,c))
            .WithMessage("Provided Id does not match to a product!");
    }
}