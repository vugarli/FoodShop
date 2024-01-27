using FluentValidation;
using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntries
{
    public class DeleteProductEntriesCommandValidator : AbstractValidator<DeleteProductEntriesCommand>
    {
        public DeleteProductEntriesCommandValidator(IProductEntryRepository repository)
        {
            RuleFor(c => c.Ids)
                .MustAsync(async (ids,cancel) => await repository.ProductEntriesExistAsync(ids,cancel))
                .WithMessage("One or more resources are not found!");
        }
    }
}
