using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.ProductEntries.Commands.CreateProductEntry;

public class CreateProductEntryCommandValidator : AbstractValidator<CreateProductEntryCommand>
{
    public CreateProductEntryCommandValidator(IProductRepository productRepository)
    {
        RuleFor(pe => pe.ProductId).NotEmpty();
        RuleFor(pe => pe.ProductId)
            .MustAsync(async (id, cancel) => await productRepository.ProductExistsAsync(id, cancel))
            .WithMessage("There is no match for given product id!");
        RuleFor(pe => pe.SKU).NotEmpty();
        RuleFor(pe => pe.Image).NotEmpty();
        RuleFor(pe => pe.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(pe => pe.Price).GreaterThanOrEqualTo(0);
    }
}