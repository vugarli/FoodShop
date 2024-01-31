using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;

namespace FoodShop.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (id ,cancelationtoken)=>
            {
                var spec = new CategoryByIdSpecification(id);
                return await repository.CheckCategoryBySpecification(spec);
            }).WithMessage("Category with Provided id does not exist");
        RuleFor(c=>c.Name)
            .NotEmpty().WithMessage("Category name must not be empty!");
    }
}