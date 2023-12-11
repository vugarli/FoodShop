using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.VariationOptions.Commands.DeleteVariationOption;

public class DeleteVariationOptionCommandHandler : IRequestHandler<DeleteVariationOptionCommand>
{
    private readonly IVariationOptionRepository _repository;

    public DeleteVariationOptionCommandHandler(IVariationOptionRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteVariationOptionCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteVariationOptionAsync(request.Id);
    }
}