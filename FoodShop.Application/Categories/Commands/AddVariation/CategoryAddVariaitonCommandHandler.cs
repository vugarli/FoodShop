using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Categories;
using FoodShop.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.AddVariation
{
    public class CategoryAddVariaitonCommandHandler : IRequestHandler<CategoryAddVariationCommand>
    {
        private ICategoryRepository _categoryRepository { get; }
        private IUnitOfWork _unitOfWork { get; }

        public CategoryAddVariaitonCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CategoryAddVariationCommand request, CancellationToken cancellationToken)
        {
            var spec = new CategoryByIdSpecification(request.CategoryId);

            var category = await _categoryRepository.GetCategoryBySpecification(spec);

            category.AddVariation(request.VariationId);

             _categoryRepository.IfVariationsAddedToCategory(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
