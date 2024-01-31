using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.DeleteCategories
{
    public class DeleteCategoriesCommandValidator : AbstractValidator<DeleteCategoriesCommand>
    {
        public DeleteCategoriesCommandValidator(ICategoryRepository repository)
        {
            RuleFor(x => x.ids).MustAsync(async (ids, cancel) =>
            {
                var spec = new CategoriesByIdsSpecification(ids);
                return await repository.CheckCategoriesBySpecification(spec,ids.Count());
            });
        }
    }
}
