using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.VariationOptions.Commands.UpdateVariationOption;

public class UpdateVariationOptionCommandValidator : AbstractValidator<UpdateVariationOptionCommand>
{
    public UpdateVariationOptionCommandValidator(IVariationOptionRepository repository)
    {
        RuleFor(c => c.Value).NotEmpty();
        RuleFor(c => c.Id)
            .MustAsync(async (id, cancel) => await repository.VariationOptionExistsAsync(id, cancel));
    }
}