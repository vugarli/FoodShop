using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Products.Commands.DeleteProducts
{
    internal class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand>
    {
        private IProductRepository _repository { get; set; }
        public DeleteProductsCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteProductsByIdsAsync(request.Ids);
        }
    }
}
