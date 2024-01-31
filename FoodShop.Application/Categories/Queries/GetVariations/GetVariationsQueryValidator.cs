using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Categories.Queries.GetCategoryById;
using FoodShop.Application.Specifications.Categories;
using FoodShop.Application.Variations.Queries.GetVariations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetVariations
{
    public class GetVariationsQueryValidator : AbstractValidator<GetVariationsQuery>
    {
        public GetVariationsQueryValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(c=>c.categoryId).MustAsync(async (Id,cancel) =>
            {
                var spec = new CategoryByIdSpecification(Id);
                return await categoryRepository.CheckCategoryBySpecification(spec);
            }).WithMessage("Category not found!");
        }
    }
}
