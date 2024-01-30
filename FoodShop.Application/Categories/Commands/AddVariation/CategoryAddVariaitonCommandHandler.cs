using FoodShop.Application.Abstractions;
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
            var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);
            category.AddVariation(request.VariationId);
             _categoryRepository.IfVariationsAddedToCategory(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
