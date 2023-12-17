using FluentValidation;
using FoodShop.Application.Abstractions;
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
            RuleFor(x => x.ids).MustAsync(async (ids, cancel) => await repository.CategoriesExistsAsync(ids, cancel));   
        }
    }
}
