using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.ProductEntries;
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
                .MustAsync(async (ids,cancel) =>
                {
                    var spec = new ProductEntriesByIdsSpecification(ids);
                    return await repository.CheckProductEntriesBySpecification(spec,ids.Count());
                })
                .WithMessage("One or more resources are not found!");
        }
    }
}
