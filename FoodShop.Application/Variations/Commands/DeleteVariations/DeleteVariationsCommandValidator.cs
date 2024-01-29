using FluentValidation;
using FoodShop.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Variations.Commands.DeleteVariations
{
    public class DeleteVariationsCommandValidator : AbstractValidator<DeleteVariationsCommand>
    {
        public DeleteVariationsCommandValidator(IVariationRepository repository)
        {
            RuleFor(c => c.Ids).MustAsync(async (ids, cancel) =>
            {
                return await repository.VariationsExistsAsync(ids, cancel);
            }).WithMessage("One or more resources are not found!");  
        }
    }
}
