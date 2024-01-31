using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
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
        var spec = new CategoryByIdSpecification(request.Id);
        await _repository.DeleteCategoriesBySpecification(spec);
    }
}