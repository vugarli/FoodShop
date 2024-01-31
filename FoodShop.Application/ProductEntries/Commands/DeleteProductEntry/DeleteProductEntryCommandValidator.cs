using System.Data;
using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.ProductEntries;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;

public class DeleteProductEntryCommandValidator : AbstractValidator<DeleteProductEntryCommand>
{
    public DeleteProductEntryCommandValidator(IProductEntryRepository repository)
    {
        RuleFor(pe => pe.Id).NotEmpty();
        RuleFor(pe => pe.Id)
            .MustAsync(async (id, cancel) =>
            {
                var spec = new ProductEntryByIdSpecification(id);
                return await repository.CheckProductEntryBySpecification(spec);
            })
            .WithMessage("Invalid product entry Id");
    }
}