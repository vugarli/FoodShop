using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.VariationOptions.Commands.DeleteVariationOption;

public class DeleteVariationOptionCommandValidator : AbstractValidator<DeleteVariationOptionCommand>
{
    public DeleteVariationOptionCommandValidator(IVariationOptionRepository repository)
    {
        RuleFor(vo => vo.Id).NotEmpty();
        RuleFor(vo => vo.Id)
            .MustAsync(async (id,cancel) => await repository.VariationOptionExistsAsync(id,cancel));
    }
}