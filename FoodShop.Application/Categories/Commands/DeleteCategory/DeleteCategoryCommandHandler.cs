using FoodShop.Application.Abstractions;
using MediatR;

namespace FoodShop.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteCategoryByIdAsync(request.Id);
    }
}