using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.VariationOptions.Commands.CreateVariationOption;

public class CreateVariationOptionCommandValidator : AbstractValidator<CreateVariationOptionCommand>
{
    public CreateVariationOptionCommandValidator(IVariationRepository repository)
    {
        RuleFor(c => c.Value).NotEmpty()
            .WithMessage("VariationOption Value can not be empth!");
        RuleFor(c => c.VariationId)
            .MustAsync(async (id, cancel) => await repository.VariationExistsAsync(id,cancel));
    }
}