using FluentValidation;
using FoodShop.Application.Abstractions;

namespace FoodShop.Application.Variations.Commands.DeleteVariation;

public class DeleteVariationCommandValidator : AbstractValidator<DeleteVariationCommand>
{
    public DeleteVariationCommandValidator(IVariationRepository repository)
    {
        RuleFor(c => c.Id).NotEmpty()
            .WithMessage("Variation Id should not be empty!");
        RuleFor(c => c.Id)
            .MustAsync(async (id, cancellationtoken) => await repository.VariationExistsAsync(id,cancellationtoken));
    }
}