using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.ProductEntries;
using MediatR;

namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntry;

public class DeleteProductEntryCommandHandler : IRequestHandler<DeleteProductEntryCommand>
{
    private readonly IProductEntryRepository _repository;

    public DeleteProductEntryCommandHandler(IProductEntryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteProductEntryCommand request, CancellationToken cancellationToken)
    {
        var spec = new ProductEntryByIdSpecification(request.Id);
        await _repository.DeleteProductEntriesBySpecification(spec);
    }
}