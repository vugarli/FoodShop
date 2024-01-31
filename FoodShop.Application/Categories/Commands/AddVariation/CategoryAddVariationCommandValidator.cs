using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.AddVariation
{
    public class CategoryAddVariationCommandValidator : AbstractValidator<CategoryAddVariationCommand>
    {
        public CategoryAddVariationCommandValidator(ICategoryRepository categoryRepository,IVariationRepository variationRepository)
        {
            RuleFor(c => c.CategoryId).MustAsync(async (c, categoryId, cancel) =>
            {
                var spec = new CategoryByIdSpecification(c.CategoryId);
                return await categoryRepository.CheckCategoryBySpecification(spec);
            }).WithMessage("Category not found!");

            RuleFor(c => c.VariationId).MustAsync(async (c, variationId, cancel) =>
            {
                return await variationRepository.VariationExistsAsync(c.VariationId, cancel);
            }).WithMessage("Variation not found!");


        }

    }
}
