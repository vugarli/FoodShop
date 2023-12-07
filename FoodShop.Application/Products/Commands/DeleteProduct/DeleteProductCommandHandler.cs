using System.Runtime.CompilerServices;
using FoodShop.Application.Abstractions;
using FoodShop.Domain.Abstractions;
using MediatR;

namespace FoodShop.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository repository,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteProductByIdAsync(request.Id);
    }
}