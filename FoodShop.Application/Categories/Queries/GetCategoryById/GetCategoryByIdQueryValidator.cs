using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;

namespace FoodShop.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (id ,cancelationtoken) =>
            {
                var spec = new CategoryByIdSpecification(id);

                return await repository.CheckCategoryBySpecification(spec);
            
            }).WithMessage("Category with Provided id does not exist");
    }
}