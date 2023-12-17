using FoodShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.DeleteCategories
{
    internal class DeleteCategoriesCommandHandler : IRequestHandler<DeleteCategoriesCommand>
    {
        public ICategoryRepository _repository { get; set; }
        public DeleteCategoriesCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCategoriesByIdsAsync(request.ids);
        }
    }
}
