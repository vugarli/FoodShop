using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (id ,cancelationtoken)=> await repository.CategoryExistsAsync(id,cancelationtoken))
            .WithMessage("Category with Provided id does not exist");
    }
}