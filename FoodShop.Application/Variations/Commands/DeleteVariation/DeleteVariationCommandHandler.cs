using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.Variations.Commands.DeleteVariation;

public class DeleteVariationCommandHandler: IRequestHandler<DeleteVariationCommand>
{
    private readonly IVariationRepository _variationRepository;

    public DeleteVariationCommandHandler(IVariationRepository variationRepository)
    {
        _variationRepository = variationRepository;
    }
    public async Task Handle(DeleteVariationCommand request, CancellationToken cancellationToken)
    {
        await _variationRepository.DeleteVariationAsync(request.Id);
    }
}