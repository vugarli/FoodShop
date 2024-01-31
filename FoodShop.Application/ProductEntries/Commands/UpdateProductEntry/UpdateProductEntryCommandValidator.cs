using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.ProductEntries;

namespace FoodShop.Application.ProductEntries.Commands.UpdateProductEntry;

public class UpdateProductEntryCommandValidator : AbstractValidator<UpdateProductEntryCommand>
{
    public UpdateProductEntryCommandValidator(IProductEntryRepository productEntryRepository,IProductRepository productRepository)
    {
        RuleFor(pe => pe.Id)
            .MustAsync(async (id, cancel) =>
            {
                var spec = new ProductEntryByIdSpecification(id);
                return await productEntryRepository.CheckProductEntryBySpecification(spec);
            })
            .WithMessage("There is no match for given ProductEntry id!");
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