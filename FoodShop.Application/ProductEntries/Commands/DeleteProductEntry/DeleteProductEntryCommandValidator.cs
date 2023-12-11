using System.Data;
using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;

public class DeleteProductEntryCommandValidator : AbstractValidator<DeleteProductEntryCommand>
{
    public DeleteProductEntryCommandValidator(IProductEntryRepository repository)
    {
        RuleFor(pe => pe.Id).NotEmpty();
        RuleFor(pe => pe.Id)
            .MustAsync(async (id, cancel) => await repository.ProductEntryExistsAsync(id, cancel))
            .WithMessage("Invalid product entry Id");
    }
}