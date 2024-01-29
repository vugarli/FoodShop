using FluentValidation;
using FoodShop.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.RemoveVariation
{
    public class RemoveVariationCommandValidator : AbstractValidator<RemoveVariationCommand>
    {
        public RemoveVariationCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(c=>c.CategoryId).MustAsync(async (c,categoryId,cancel) =>
            {
                return await categoryRepository.IsVariationBelongsToCategoryAsync(c.CategoryId,c.VariationId);
            });
        }
    }
}
